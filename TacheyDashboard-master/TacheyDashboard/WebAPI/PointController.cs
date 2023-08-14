using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TacheyDashboard.Interface;
using TacheyDashboard.ViewModel.ApiModel;
using TacheyDashboard.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TacheyDashboard.WebAPI
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PointController : ControllerBase
    {
        private readonly OrderInterface _ordersService;
        public PointController(OrderInterface orderservice)
        {
            _ordersService = orderservice;
        }

        /// <summary>
        /// 取得積分資料
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ApiResult Get()
        {
            try
            {
                var result = _ordersService.GetPoint();
                return new ApiResult(ApiStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new ApiResult(ApiStatus.Fail, ex.Message, null);
            }
        }

        /// <summary>
        /// 編輯 積分券
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut]
        public ApiResult Put([FromBody] Point value)
        {
            try
            {
                var result = _ordersService.UpdatePoint(value);
                return new ApiResult(ApiStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new ApiResult(ApiStatus.Fail, ex.Message, null);
            }
        }

        /// <summary>
        /// 新增積分
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult Post([FromBody] Point value)
        {
            try
            {
                var result = _ordersService.CreatePoint(value);
                return new ApiResult(ApiStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new ApiResult(ApiStatus.Fail, ex.Message, null);
            }
        }

        /// <summary>
        /// 發送積分券
        /// </summary>
        /// <param name="id"></param>
        [HttpPatch("{id}")]
        public ApiResult Patch(int id)
        {
            try
            {
                var result = _ordersService.SendPoint(id);
                return new ApiResult(ApiStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new ApiResult(ApiStatus.Fail, ex.Message, null);
            }
        }

        /// <summary>
        /// 刪除積分券
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public ApiResult Delete(int id)
        {
            try
            {
                var result = _ordersService.GetPoint();
                return new ApiResult(ApiStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new ApiResult(ApiStatus.Fail, ex.Message, null);
            }
        }
    }
}
