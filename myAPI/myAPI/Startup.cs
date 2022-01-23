using BLL;
using DAL.Context;
using DAL.Repos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionStr = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<EnContactoContext>(options => options.UseSqlServer(connectionStr), ServiceLifetime.Scoped);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.RequireHttpsMetadata = false;
                    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = Configuration["Jwt:Audience"],
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"])),
                        ValidateLifetime = false
                    };
                });
            services.AddScoped<DbContext, EnContactoContext>();
            services.AddScoped<IRepo<User>, UserRepo>();

            services.AddScoped<IRepo<Comment>, CommentRepo>();

            services.AddScoped<IRepo<Gender>, GenderRepo>();
            services.AddScoped<IRepo<Post>, PostRepo>();

            services.AddScoped<IRepo<UserAudio>, UserAudioRepo>();
            services.AddScoped<IRepo<UserDocument>, UserDocumentRepo>();
            services.AddScoped<IRepo<UserInfo>, UserInfoRepo>();
            services.AddScoped<IRepo<UserPhoto>, UserPhotoRepo>();
            services.AddScoped<IRepo<UserVideo>, UserVideoRepo>();
            services.AddScoped<IRepo<Friendship>, FriendshipRepo>();
            services.AddScoped<IRepo<Subscribition>, SubscribitionRepo>();
            services.AddScoped<IRepo<LikedEntity>, LikedEntityRepo>();


            services.AddScoped<VisibilityManager>(provider =>
            {
                var dependency = provider.GetRequiredService<IRepo<Visibility>>();
                return new VisibilityManager(dependency);
            });
            services.AddScoped<CommunityManager>(provider =>
            {
                var dependency = provider.GetRequiredService<IRepo<Community>>();
                return new CommunityManager(dependency);
            });
            services.AddScoped<UserManager>(provider =>
            {
                var dependency = provider.GetRequiredService<IRepo<User>>();
                return new UserManager(dependency);
            });

            services.AddScoped<CommentManager>(provider =>
            {
                var dependency = provider.GetRequiredService<IRepo<Comment>>();
                return new CommentManager(dependency);
            });

            services.AddScoped<GenderManager>(provider =>
            {
                var dependency = provider.GetRequiredService<IRepo<Gender>>();
                return new GenderManager(dependency);
            });

            services.AddScoped<PostManager>(provider =>
            {
                var dependency = provider.GetRequiredService<IRepo<Post>>();
                return new PostManager(dependency);
            });
            services.AddScoped<UserAudioManager>(provider =>
            {
                var dependency = provider.GetRequiredService<IRepo<UserAudio>>();
                return new UserAudioManager(dependency);
            });
            services.AddScoped<UserPhotoManager>(provider =>
            {
                var dependency = provider.GetRequiredService<IRepo<UserPhoto>>();
                return new UserPhotoManager(dependency);
            });
            services.AddScoped<UserDocumentManager>(provider =>
            {
                var dependency = provider.GetRequiredService<IRepo<UserDocument>>();
                return new UserDocumentManager(dependency);
            });
            services.AddScoped<UserInfoManager>(provider =>
            {
                var dependency = provider.GetRequiredService<IRepo<UserInfo>>();
                return new UserInfoManager(dependency);
            });
            services.AddScoped<UserVideoManager>(provider =>
            {
                var dependency = provider.GetRequiredService<IRepo<UserVideo>>();
                return new UserVideoManager(dependency);
            });
            services.AddScoped<FriendshipManager>(provider =>
            {
                var dependency = provider.GetRequiredService<IRepo<Friendship>>();
                return new FriendshipManager(dependency);
            });
            services.AddScoped<SubscribitionManager>(provider =>
            {
                var dependency = provider.GetRequiredService<IRepo<Subscribition>>();
                return new SubscribitionManager(dependency);
            });
            services.AddScoped<LikedEntityManager>(provider =>
            {
                var dependency = provider.GetRequiredService<IRepo<LikedEntity>>();
                return new LikedEntityManager(dependency);
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "myAPI", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "myAPI v1"));
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseStaticFiles();

           
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
