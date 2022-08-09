using System;
using System.Linq.Expressions;

namespace Tidy_EDL_for_Pro_Tools
{
	public static partial class UserSettings
	{
		public static class MemberInfoGetting
		{
			public static string GetMemberName<T>(Expression<Func<T>> memberExpression)
			{
				MemberExpression expressionBody = (MemberExpression)memberExpression.Body;
				return expressionBody.Member.Name;
			}
		}

	}


}
