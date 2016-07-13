using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using EZ.Framework;
using EZ.Framework.Integration.WebApi;
using Vanke.WX.Weixin.App_Extension;
using Vanke.WX.Weixin.Common;
using Vanke.WX.Weixin.Data.Entity;
using Vanke.WX.Weixin.Service.Interface;
using Vanke.WX.Weixin.Service.Models;
using Vanke.WX.Weixin.ViewModels;

namespace Vanke.WX.Weixin.Controllers
{
    public class IdleAssetsController : GenericApiController
    {
        private readonly IIdleAssetService _service = IoC.Container.GetInstance<IIdleAssetService>();

        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<IdleAssetModel>> Get()
        {
            return await _service.GetAllAsync();
        }

        /// <summary>
        /// Get item by key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IdleAssetModel> Get(long id)
        {
            return await _service.GetByKeyAsync(id);
        }

        /// <summary>
        /// Insert/Update item
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Save(IdleAssetModel model)
        {
            if (model.ID.Equals(0))
            {
                await _service.InsertAsync(model);
            }
            else
            {
                await _service.UpdateAsync(model.ID, model);
            }
        }

        [HttpPost]
        [Route("api/idleassets/import")]
        public async Task Import(IdleAssetImportModel viewModel)
        {
            var filePath = HttpRuntime.AppDomainAppPath + @"Temp\" + viewModel.FileName;
            var dataSource = ExcelHelper.GetExcelDataTable(filePath);

            var itemStorageAreaService = IoC.Container.GetInstance<IItemStorageAreaService>();
            var itemStoragePlaceService = IoC.Container.GetInstance<IItemStoragePlaceService>();
            var staffService = IoC.Container.GetInstance<IStaffService>();
            var idleAssetService = IoC.Container.GetInstance<IIdleAssetService>();

            var checkedArea = new Dictionary<string, long>();
            var checkedPlace = new Dictionary<string, long>();
            var checkedManagerAccount = new Dictionary<string, long>();
            int index;

            #region 验证Excel格式

            index = 2;
            foreach (DataRow row in dataSource.Rows)
            {
                if (string.IsNullOrEmpty(row[0].ToString()) &&
                    string.IsNullOrEmpty(row[1].ToString()) &&
                    string.IsNullOrEmpty(row[2].ToString()) &&
                    string.IsNullOrEmpty(row[3].ToString()) &&
                    string.IsNullOrEmpty(row[4].ToString()) &&
                    string.IsNullOrEmpty(row[5].ToString()) &&
                    string.IsNullOrEmpty(row[6].ToString()))
                {
                    break;
                }

                if (string.IsNullOrEmpty(row[0].ToString()))
                {
                    throw new BusinessException($"第{index}行项目名称为空");
                }
                if (string.IsNullOrEmpty(row[1].ToString()))
                {
                    throw new BusinessException($"第{index}行闲置资产物品为空");
                }
                if (string.IsNullOrEmpty(row[2].ToString()))
                {
                    throw new BusinessException($"第{index}行数量为空");
                }
                if (string.IsNullOrEmpty(row[3].ToString()))
                {
                    throw new BusinessException($"第{index}行单位为空");
                }
                if (string.IsNullOrEmpty(row[4].ToString()))
                {
                    throw new BusinessException($"第{index}行物品管理负责人为空");
                }
                if (string.IsNullOrEmpty(row[5].ToString()))
                {
                    throw new BusinessException($"第{index}行负责人账号为空");
                }
                if (string.IsNullOrEmpty(row[6].ToString()))
                {
                    throw new BusinessException($"第{index}行备注为空");
                }

                index++;
            }

            #endregion

            #region 验证基础数据是否存在

            index = 2;
            foreach (DataRow row in dataSource.Rows)
            {
                if (string.IsNullOrEmpty(row[0].ToString()) &&
                    string.IsNullOrEmpty(row[1].ToString()) &&
                    string.IsNullOrEmpty(row[2].ToString()) &&
                    string.IsNullOrEmpty(row[3].ToString()) &&
                    string.IsNullOrEmpty(row[4].ToString()) &&
                    string.IsNullOrEmpty(row[5].ToString()) &&
                    string.IsNullOrEmpty(row[6].ToString()))
                {
                    break;
                }

                // 验证项目名称
                var area = row[0].ToString();
                long areaId = 0;
                if (!checkedArea.ContainsKey(area))
                {
                    var entity = await itemStorageAreaService.GetByNameAsync(area);
                    if (entity != null)
                    {
                        checkedArea.Add(area, entity.ID);
                        areaId = entity.ID;
                    }
                    else
                    {
                        throw new BusinessException($"第{index}行项目名称{area}不存在，请先创建");
                    }
                }
                else
                {
                    areaId = checkedArea[area];
                }

                // 验证存放地点
                var place = row[6].ToString();
                if (!checkedPlace.ContainsKey(place + "|" + areaId))
                {
                    var entity = await itemStoragePlaceService.GetByNameAsync(areaId, place);
                    if (entity != null)
                    {
                        checkedPlace.Add(place + "|" + areaId, entity.ID);
                    }
                    else
                    {
                        throw new BusinessException($"第{index}行备注{place}不存在，请先创建");
                    }
                }

                // 验证负责人账号
                var managerAccount = row[5].ToString();
                if (!checkedManagerAccount.ContainsKey(managerAccount))
                {
                    var entity = await staffService.GetByLoginNameAsync(managerAccount);
                    if (entity != null)
                    {
                        checkedManagerAccount.Add(managerAccount, entity.ID);
                    }
                    else
                    {
                        throw new BusinessException($"第{index}行负责人账号不存在{managerAccount}不存在，请先创建");
                    }
                }

                index++;
            }

            #endregion

            #region 导入

            index = 2;
            foreach (DataRow row in dataSource.Rows)
            {
                if (string.IsNullOrEmpty(row[0].ToString()) &&
                    string.IsNullOrEmpty(row[1].ToString()) &&
                    string.IsNullOrEmpty(row[2].ToString()) &&
                    string.IsNullOrEmpty(row[3].ToString()) &&
                    string.IsNullOrEmpty(row[4].ToString()) &&
                    string.IsNullOrEmpty(row[5].ToString()) &&
                    string.IsNullOrEmpty(row[6].ToString()))
                {
                    break;
                }

                var model = new IdleAssetModel
                {
                    AreaID = checkedArea[row[0].ToString()],
                    PlaceID = checkedPlace[row[6].ToString()+"|"+ checkedArea[row[0].ToString()]],
                    Item = row[1].ToString(),
                    Quantity = Convert.ToInt32(row[2]),
                    Unit = row[3].ToString(),
                    ManagerStaffID = checkedManagerAccount[row[5].ToString()]
                };

                await idleAssetService.InsertOrUpdate(model);
            }

            #endregion
        }

        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task Delete(long id)
        {
            await _service.RemoveAsync(id);
        }
    }
}
