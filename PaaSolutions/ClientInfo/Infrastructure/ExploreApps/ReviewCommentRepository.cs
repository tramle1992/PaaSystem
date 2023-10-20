using Common.Infrastructure.Repository;
using Core.Domain.Model.ExploreApps;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Common.Infrastructure.Helper;

namespace Core.Infrastructure.ExploreApps
{
    public class ReviewCommentRepository : Repository<ReviewComment, string>
    {

        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ReviewCommentRepository()
        { }

        public override void Add(ReviewComment item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string insertStatement = @"insert review_comment(review_comment_id, areas, comment) " +
                        "values (@review_comment_id, @areas, @comment) ";
                    var args = new DynamicParameters();
                    args.Add("review_comment_id", item.ReviewCommentId);
                    args.Add("comment", item.Comment);
                    if (item.Areas != null)
                    {
                        args.Add("areas", XmlSerializationHelper.Serialize<List<string>>(item.Areas));
                    }
                    cn.Execute(insertStatement, args);
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public override void Remove(ReviewComment item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string deleteStatement = @"delete from review_comment where review_comment_id = @review_comment_id";

                    cn.Execute(deleteStatement, new { review_comment_id = item.ReviewCommentId });
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public void Remove(string id)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string deleteStatement = @"delete from review_comment where review_comment_id = @review_comment_id";

                    cn.Execute(deleteStatement, new { review_comment_id = id });
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public override void Update(ReviewComment item)
        {
            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string updateStatement = @"update review_comment set areas=@areas, comment=@comment " +
                        "where review_comment_id=@review_comment_id ";
                    var args = new DynamicParameters();
                    args.Add("review_comment_id", item.ReviewCommentId);
                    args.Add("comment", item.Comment);
                    if (item.Areas != null)
                    {
                        args.Add("areas", XmlSerializationHelper.Serialize<List<string>>(item.Areas));
                    }
                    cn.Execute(updateStatement, args);
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        public override ReviewComment Find(string id)
        {
            ReviewComment reviewComment = null;

            if (string.IsNullOrEmpty(id))
            {
                return reviewComment;
            }

            try
            {
                using (IDbConnection cn = Connection)
                {
                    cn.Open();

                    string findStatement = @"select review_comment_id, areas, comment " +
                        " from review_comment where review_comment_id=@review_comment_id";

                    dynamic item = cn.Query<dynamic>(findStatement, new { review_comment_id = id }).FirstOrDefault();
                    if (item != null && !string.IsNullOrEmpty(item.review_comment_id))
                    {
                        reviewComment = new ReviewComment();
                        if (!string.IsNullOrEmpty(item.areas) && !string.IsNullOrEmpty(item.areas))
                        {
                            reviewComment.Areas = XmlSerializationHelper.Deserialize<List<string>>(item.areas);
                        }
                        reviewComment.Comment = item.comment;
                        reviewComment.ReviewCommentId = item.review_comment_id;
                    }
                }
            }
            catch (SqlException ex)
            {
                _logger.Error(ex);
                throw;
            }
            return reviewComment;
        }
    }

}
