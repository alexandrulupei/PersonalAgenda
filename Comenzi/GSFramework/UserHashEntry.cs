using System;

namespace GSFramework
{
   /// <summary>
   /// Summary description for UserHashEntry.
   /// </summary>
   public class UserHashEntry
   {
      #region Member variables
      private object mKey;
      private object mValue;
      #endregion

      #region properties
      public object Key
      {
         set
         {
            mKey = value;
         }
         get
         {
            return( mKey );
         }
      }
      public object Value
      {
         set
         {
            mValue = value;
         }
         get
         {
            return( mValue );
         }
      }
      #endregion

      #region Constructors
      public UserHashEntry()
      {
      }

      public UserHashEntry( object pKey, object pValue )
      {
         mKey = pKey;
         mValue = pValue;
      }
      #endregion
   }
}
