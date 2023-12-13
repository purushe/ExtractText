using System;
using System.Linq;
using TextReader.RepositoryModel.RepositoryModel;
using TextReader.Utility;

namespace TextReader.Repository.Helper
{

  public static class FieldSortingUtility
  {

    public static IQueryable<TEntity> EntitySortByDatatableParam<TEntity>(IQueryable<TEntity> queryTable, DTParameters param, Func<IOrderedQueryable<TEntity>, string, IOrderedQueryable<TEntity>> orderCall)
    {
      var query = queryTable.OrderBy(p => 0);
      if (param.Order != null && param.Order.Length > 0)
      {
        foreach (var item in param.Order)
        {
          var columnOrderKey = param.Columns[item.Column].Data + (item.Dir == DTOrderDir.DESC ? " " + item.Dir : string.Empty);
          query = orderCall(query, columnOrderKey);
        }
      }
      queryTable = query;
      return queryTable;
    }


    public static IOrderedQueryable<RegistrationRepositoryModel> UserSort(IOrderedQueryable<RegistrationRepositoryModel> query, string sortOrder)
    {
      if (!string.IsNullOrEmpty(sortOrder))
      {
        switch (sortOrder)
        {
          case "firstName":
            query = query.ThenBy(x => x.FirstName);
            break;

          case "firstName DESC":
            query = query.ThenByDescending(x => x.FirstName);
            break;

          case "lastName":
            query = query.ThenBy(x => x.LastName);
            break;

          case "lastName DESC":
            query = query.ThenByDescending(x => x.LastName);
            break;

          case "email":
            query = query.ThenBy(x => x.Email);
            break;

          case "email DESC":
            query = query.ThenByDescending(x => x.Email);
            break;

          case "mobileNumber":
            query = query.ThenBy(x => x.MobileNumber);
            break;

          case "mobileNumber DESC":
            query = query.ThenByDescending(x => x.MobileNumber);
            break;

          case "userName":
            query = query.ThenBy(x => x.UserName);
            break;

          case "userName DESC":
            query = query.ThenByDescending(x => x.UserName);
            break;

          default:
            query = query.ThenBy(x => x.FirstName);
            break;
        }
      }
      return query;
    }
  }

  //public static class FieldSortingUtility
  //{
  //    public static IQueryable<TEntity> EntitySortByDatatableParam<TEntity>(IQueryable<TEntity> queryTable, DTParameters param, Func<IOrderedQueryable<TEntity>, string, IOrderedQueryable<TEntity>> orderCall)
  //    {
  //        var query = queryTable.OrderBy(p => 0);
  //        if (param.Order != null && param.Order.Length > 0)
  //        {
  //            foreach (var item in param.Order)
  //            {
  //                var columnOrderKey = param.Columns[item.Column].Data + (item.Dir == DTOrderDir.DESC ? " " + item.Dir : string.Empty);
  //                query = orderCall(query, columnOrderKey);
  //            }
  //        }
  //        return query;
  //    }

  //    public static IOrderedQueryable<CategoryRepositoryModel> FaqFieldSort(IOrderedQueryable<CategoryRepositoryModel> query, string sortOrder)
  //    {
  //        if (!string.IsNullOrEmpty(sortOrder))
  //        {
  //            switch (sortOrder)
  //            {
  //                case "CategoryName":
  //                    query = query.ThenBy(x => x.CategoryName);
  //                    break;

  //                case "CategoryName DESC":
  //                    query = query.ThenByDescending(x => x.CategoryName);
  //                    break;

  //                case "CategoryType":
  //                    query = query.ThenBy(x => x.CategoryType);
  //                    break;

  //                case "CategoryType DESC":
  //                    query = query.ThenByDescending(x => x.CategoryType);
  //                    break;

  //                case "CategoryImage":
  //                    query = query.ThenBy(x => x.CategoryImage);
  //                    break;

  //                case "CategoryImage DESC":
  //                    query = query.ThenByDescending(x => x.CategoryImage);
  //                    break;

  //                case "IsDeleted":
  //                    query = query.ThenBy(x => x.IsDeleted);
  //                    break;

  //                case "IsDeleted DESC":
  //                    query = query.ThenByDescending(x => x.IsDeleted);
  //                    break;

  //                default:
  //                    query = query.ThenBy(x => x.CategoryName);
  //                    break;
  //            }
  //        }
  //        return query;
  //    }
  //}
}
