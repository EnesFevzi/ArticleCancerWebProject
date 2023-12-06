using ArticleCancer.Application.AutoMapper.Users;
using ArticleCancer.Application.FluentValidations.Articles;
using ArticleCancer.Infrastructure.Helpers.Images;
using ArticleCancer.Infrastructure.Services.Abstract;
using ArticleCancer.Infrastructure.Services.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NewCancer.Infrastructure.Services.Abstract;
using System.Globalization;
using System.Reflection;

namespace ArticleCancer.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddScoped<IImageHelper, ImageHelper>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<INewService, NewService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddAutoMapper(typeof(UserProfile));
			services.AddControllersWithViews()
                .AddFluentValidation(opt =>
                {
                    opt.RegisterValidatorsFromAssemblyContaining<ArticleValidator>();
                    opt.DisableDataAnnotationsValidation = true;
                    opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
                });

            return services;


        }
    }
}
