using AutoMapper;
using sport_shop_bll.Interfaces;
using sport_shop_bll.Models.GET;
using sport_shop_bll.Models.POST;
using sport_shop_bll.Models.UPDATE;
using sport_shop_dal.Entities;
using sport_shop_dal.Interfaces;
using System.Net;
using System.Net.Mail;

namespace sport_shop_bll.Services
{
    public class OrderService : IOrdersService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<OrderGet> AddAsync(OrderPost model)
        {

            var entity = mapper.Map<Order>(model);
            var created = await unitOfWork.OrderRepository.CreateAsync(entity);
            var client = await unitOfWork.AccountRepository.GetAsync(model.AccountId);

            SendMessage(client.Email, 
                messageBody: $"<h2>Thanks for your order</h2><span>We will proccess your order as soon as possible.        Your order ID is <b>{created.Id}</b>    </span>",
                messageSubject: "Thanks for your order!");

            await unitOfWork.ProductRepository.PurchasesInc(model.ProductId);
            return mapper.Map<OrderGet>(created);
        }

        async void SendMessage(string email, string messageBody, string messageSubject)
        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("maksimsevcenko250@gmail.com", "Fury Sports - unleash your inner beast");
            // кому отправляем
            MailAddress to = new MailAddress(email);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = messageSubject;
            // текст письма
            m.Body = messageBody;
            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("maksimsevcenko250@gmail.com", "dkyi rmzd lpeu dgak");
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);
        }

        public async Task<OrderGet> ChangeStatusAsync(int orderId, int statusCode)
        {
            var changed = await unitOfWork.OrderRepository.ChangeStatusAsync(orderId, statusCode);

            var entity = await unitOfWork.OrderRepository.GetAsync(orderId);
            var client = await unitOfWork.AccountRepository.GetAsync(entity.AccountId.HasValue ? entity.AccountId.Value : 0);
            SendMessage(client.Email, $"Your order <b>{orderId}</b> has changed. Check it out on your profile's page"
                , "Your order has changed");

            return mapper.Map<OrderGet>(changed);
        }

        public async Task<bool> DeleteAsync(OrderUpdate model)
        {
            try
            {
                await unitOfWork.OrderRepository.DeleteAsync(mapper.Map<Order>(model));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteByIdAsync(int modelId)
        {
            try
            {
                await unitOfWork.OrderRepository.DeleteAsync(modelId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<OrderGet>> GetAllAsync()
        {
            var entities = await unitOfWork.OrderRepository.GetAllAsync();
            return entities.Select(e => mapper.Map<OrderGet>(e));
        }


        public async Task<OrderGet?> GetByIdAsync(int id)
        {
            return mapper.Map<OrderGet>(await unitOfWork.OrderRepository.GetAsync(id));
        }

        public async Task<IEnumerable<OrderGet>> GetByUserId(int userId)
        {
            var entities = await unitOfWork.OrderRepository.GetByUserId(userId);
            return entities.Select(mapper.Map<OrderGet>);
        }

        public async Task<OrderGet?> UpdateAsync(OrderUpdate model, int id)
        {
            var entity = mapper.Map<Order>(model);
            entity.Id = id;
            var updated = unitOfWork.OrderRepository.Update(entity);
            var client = await unitOfWork.AccountRepository.GetAsync(updated.AccountId.HasValue ? updated.AccountId.Value : 0);
            SendMessage(client.Email, $"Your order <b>{id}</b> has changed. Check it out on your profile's page"
                , "Your order has changed");
            return mapper.Map<OrderGet>(updated);
        }
    }
}
