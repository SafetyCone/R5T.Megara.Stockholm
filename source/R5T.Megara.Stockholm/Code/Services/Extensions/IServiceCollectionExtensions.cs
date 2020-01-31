using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Stockholm;


namespace R5T.Megara.Stockholm
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="IStreamSerializer{T}"/> implementation of <see cref="IFileSerializer{T}"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddStreamFileSerializer<T>(this IServiceCollection services,
            ServiceAction<IStreamSerializer<T>> addStreamSerializer)
        {
            services
                .AddSingleton<IFileSerializer<T>, StreamFileSerializer<T>>()
                .RunServiceAction(addStreamSerializer)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="IStreamSerializer{T}"/> implementation of <see cref="IFileSerializer{T}"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static ServiceAction<IFileSerializer<T>> AddStreamFileSerializerAction<T>(this IServiceCollection services,
            ServiceAction<IStreamSerializer<T>> addStreamSerializer)
        {
            var serviceAction = new ServiceAction<IFileSerializer<T>>(() => services.AddStreamFileSerializerAction<T>(addStreamSerializer));
            return serviceAction;
        }
    }
}
