﻿using ArticleCancer.Application.DTOs.Messages;
using ArticleCancer.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.FluentValidations.Messages
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.Subject)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(150)
                .WithName("Konu");

            RuleFor(x => x.MessageDetails)
                .NotEmpty()
                .NotNull()
                 .MinimumLength(3)
                .MaximumLength(150)
               .WithName("Mesaj Konusu");
        }
    }
    public class SendMessageValidator : AbstractValidator<SendMessageDto>
    {
        public SendMessageValidator()
        {

            RuleFor(x => x.ReceiverMail)
                .NotEmpty()
                .NotNull()
                 .MinimumLength(3)
                .MaximumLength(150)
               .WithName("Alıcı");
        }
    }
}
