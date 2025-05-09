﻿using OzonEdu.StockApi.Domain.Contracts;

namespace OzonEdu.StockApi.Domain.AggregationModels.DeliveryRequestAggregate
{
	public interface IDeliveryRequestRepository : IRepository<DeliveryRequest>
	{
		/// <summary>
		/// Получить заявку по идентификатору
		/// </summary>
		/// <param name="id">Идентификатор заявки</param>
		/// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
		/// <returns>Объект заявки</returns>
		Task<DeliveryRequest> FindByIdAsync(int id, CancellationToken cancellationToken = default);

		/// <summary>
		/// Получить заявку по номеру заявки
		/// </summary>
		/// <param name="stockItem">Номер заявки</param>
		/// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
		/// <returns>Объект заявки</returns>
		Task<DeliveryRequest> FindByRequestNumberAsync(RequestNumber requestNumber,
			CancellationToken cancellationToken = default);
	}
}
