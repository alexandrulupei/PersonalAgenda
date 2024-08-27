using System;

namespace GSBusFramework
{
	/// <summary>
	/// Summary description for FilterInfo.
	/// </summary>
	public class FilterInfo
	{
		// Public internal classes
		public enum FilterMatchCriterion 
		{
			FILTER_MATCHNUMERIC_EQUAL,
			FILTER_MATCHNUMERIC_LESSTHAN,
			FILTER_MATCHNUMERIC_LESSTHANEQUAL,
			FILTER_MATCHNUMERIC_GREATERTHAN,
			FILTER_MATCHNUMERIC_GREATERTHANEQUAL,

			FILTER_MATCHSTRING_EQUAL,
         FILTER_MATCHSTRING_EQUAL_NOESCAPE,
			FILTER_MATCHSTRING_LIKE_NOREGEXP,
			FILTER_MATCHSTRING_LIKE_STARTWITH_NOREGEXP,
			FILTER_MATCHSTRING_LIKE_ENDWITH_NOREGEXP,
			FILTER_MATCHSTRING_LIKE_REGEXP,

			FILTER_MATCHOBJECT_EQUAL,
		};

		// Member fields
		private String mColumnToMatch;
		private String mValueToMatch;
		private Object mObjectToMatch;
		private FilterMatchCriterion mHowToMatch;

		#region Properties
		public String FilterVar 
		{
			get 
			{
				return mColumnToMatch;
			}
		}
		public Object FilterValue 
		{
			get 
			{
				if (mHowToMatch == FilterMatchCriterion.FILTER_MATCHSTRING_LIKE_REGEXP)
				{
					return this.renderRegexpForString (mValueToMatch);
				}
				else if (mHowToMatch == FilterMatchCriterion.FILTER_MATCHOBJECT_EQUAL)
				{
					return mObjectToMatch;
				}
            else if (mHowToMatch == FilterMatchCriterion.FILTER_MATCHSTRING_EQUAL_NOESCAPE)
            {
               return mValueToMatch;
            }
				else
				{
					return ( mValueToMatch.Replace( "'", "''" ) );
				}
			}
		}
		#endregion

		#region Constructors
		public FilterInfo()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public FilterInfo (String pColToMatch, String pValToMatch,
			FilterMatchCriterion pHowToMatch)
		{
			mColumnToMatch = pColToMatch;
			mValueToMatch = pValToMatch;
			mHowToMatch = pHowToMatch;
		}
		public FilterInfo (String pColToMatch, Object pValToMatch,
			FilterMatchCriterion pHowToMatch)
		{
			mColumnToMatch = pColToMatch;
			mObjectToMatch = pValToMatch;
			mHowToMatch = pHowToMatch;
		}
		#endregion

		#region Public methods
		public String RenderFilterForSQL ()
		{
			String retStr = null;
			if (mColumnToMatch != null && mValueToMatch != null)
			{
				String numCompare = null;
				mValueToMatch = mValueToMatch.Replace( "'", "''" );
				switch (mHowToMatch)
				{
					case FilterMatchCriterion.FILTER_MATCHNUMERIC_EQUAL:
						numCompare = " = ";
						break;
					case FilterMatchCriterion.FILTER_MATCHNUMERIC_LESSTHAN:
						numCompare = " < ";
						break;
					case FilterMatchCriterion.FILTER_MATCHNUMERIC_LESSTHANEQUAL:
						numCompare = " <= ";
						break;
					case FilterMatchCriterion.FILTER_MATCHNUMERIC_GREATERTHAN:
						numCompare = " > ";
						break;
					case FilterMatchCriterion.FILTER_MATCHNUMERIC_GREATERTHANEQUAL:
						numCompare = " >= ";
						break;

					case FilterMatchCriterion.FILTER_MATCHSTRING_EQUAL:
						numCompare = " = ";
						break;
					case FilterMatchCriterion.FILTER_MATCHSTRING_LIKE_STARTWITH_NOREGEXP:
						retStr = mColumnToMatch + " LIKE '" + mValueToMatch + "%'";
						break;
					case FilterMatchCriterion.FILTER_MATCHSTRING_LIKE_ENDWITH_NOREGEXP:
						retStr = mColumnToMatch + " LIKE '%" + mValueToMatch + "'";
						break;
					case FilterMatchCriterion.FILTER_MATCHSTRING_LIKE_NOREGEXP:
						retStr = mColumnToMatch + " LIKE '%" + mValueToMatch + "%'";
						break;
					case FilterMatchCriterion.FILTER_MATCHSTRING_LIKE_REGEXP:
					{
						retStr = mColumnToMatch + " LIKE '" +
							renderRegexpForString (mValueToMatch) + "'";
						break;
					}
					default:
						break;
				}
				if (numCompare != null)
				{
					retStr = mColumnToMatch + numCompare + mValueToMatch;
				}
			}
			return (retStr);
		}

		#endregion

		#region Private Methods
		private String renderRegexpForString (String filterStr)
		{
			String regExp = "%";
			foreach (char c in filterStr)
			{
				regExp = regExp + "[" + char.ToLower(c) + char.ToUpper(c) + "]";
			}
			regExp += "%";
			return (regExp);
		}
		#endregion
	}
}
