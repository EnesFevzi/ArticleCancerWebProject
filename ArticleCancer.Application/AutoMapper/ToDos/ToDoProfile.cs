using ArticleCancer.Application.DTOs.Categories;
using ArticleCancer.Application.DTOs.ToDos;
using ArticleCancer.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.AutoMapper.ToDos
{
    public class ToDoProfile : Profile
    {
        public ToDoProfile()
        {
            CreateMap<ToDoDto, ToDo>().ReverseMap();
            CreateMap<ToDoAddDto, ToDo>().ReverseMap();
            CreateMap<ToDoUpdateDto, ToDo>().ReverseMap();
            CreateMap<ToDoUpdateDto, ToDoDto>().ReverseMap();
        }
    }
}
