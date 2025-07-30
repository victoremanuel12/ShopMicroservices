﻿using Discount.Grpc.Data;
using Discount.Grpc.Models;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Services
{
    public class DiscountService(DiscountContext dbContext, ILogger<DiscountService> logger) : DiscountProtoService.DiscountProtoServiceBase
    {
        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await dbContext.Coupons.FirstOrDefaultAsync(p => p.ProductName == request.ProductName);
            if (coupon is null)
                coupon = new Coupon
                {
                    ProductName = "No Discount",
                    Description = "No Discount Description",
                    Amount = 0
                };
            logger.LogInformation("Discount is retrieved for ProductName: {ProductName}, Amount: {Amount}", coupon.ProductName, coupon.Amount);
            var couponModel = coupon.Adapt<CouponModel>();
            return couponModel;
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();
            if (coupon is null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Coupon cannot be null"));
            dbContext.Coupons.Add(coupon);
            await dbContext.SaveChangesAsync();
            logger.LogInformation("Discount is successfully created for ProductName: {ProductName}, Amount: {Amount}", coupon.ProductName, coupon.Amount);
            var couponModel = coupon.Adapt<CouponModel>();
            return couponModel;
        }
        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = await dbContext.Coupons.FirstOrDefaultAsync(p => p.Id == request.Coupon.Id);
            if (coupon is null)
                throw new RpcException(new Status(StatusCode.NotFound, "Coupon not found"));
            request.Coupon.Adapt(coupon);
            dbContext.Coupons.Update(coupon);
            await dbContext.SaveChangesAsync();
            logger.LogInformation("Discount is successfully updated for ProductName: {ProductName}, Amount: {Amount}", coupon.ProductName, coupon.Amount);
            var couponModel = coupon.Adapt<CouponModel>();
            return couponModel;
        }
        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var coupon = await dbContext.Coupons.FirstOrDefaultAsync(p => p.Id == request.Coupon.Id);
            if (coupon is null)
                throw new RpcException(new Status(StatusCode.NotFound, "Coupon not found"));
            dbContext.Coupons.Remove(coupon);
            await dbContext.SaveChangesAsync();

            return new DeleteDiscountResponse{ Success = true};
        }
    }
}
