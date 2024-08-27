using System;
using System.Configuration;

namespace GSBusFramework
{
	/// <summary>
	/// Summary description for GS_Config.
	/// This class will get the values for the given property
	/// These values will be fetched from Config file
	/// If the property is not available in either of them, Then String.Emtpy will be returned.
	/// </summary>
	public class GS_Config
	{
		#region Member Variables
		private String mMachineName = string.Empty; //If machine name is not provided, then default machine name is used.
		private System.Collections.Hashtable mConfigProps = null;
		private System.Collections.Hashtable mADProps = null;
		private bool IsConfigChecked = false;

		private String mServerName = String.Empty; // This value will be read from Config file.
		private String mADsDomainPath = String.Empty;
		private	String mProvider = String.Empty;
		private String mERROR = String.Empty;
		#endregion

		#region SINGLETON 
		private static GS_Config OnlyInstance = null;
		public GS_Config()
		{
			mServerName = this.GetServerName();	
			mADsDomainPath = string.Empty;
		}
		public static GS_Config GetInstance()
		{
			if(OnlyInstance == null)
			{
				OnlyInstance = new GS_Config();
			}
			return(OnlyInstance);
		}
		#endregion

		#region Public Methods
		//search for peroperties with machine name
		//cache the property values in the hashtable
		public String GetConfigPropertyValue(String pMachineName, String pPropertyName)
		{
			try
			{
				if(pMachineName == String.Empty)
				{
					mMachineName = Environment.MachineName;
				}
				mMachineName = pMachineName;
				String mPropName = pPropertyName.ToLower();
				String mPropValue = String.Empty;
			
				//verify for property cache either from Config or AD
				if(!IsConfigChecked)
				{
					if(mConfigProps == null)
					{
						mConfigProps = GetPropertyCacheFromConfig();
						IsConfigChecked = true;
					}
				}
				if(mConfigProps != null)
				{
					mPropValue = (String)mConfigProps[mPropName];
				}
				if((mPropValue == String.Empty) ||(mPropValue == null )) 
				{
					if(mADProps != null)
					{
						mPropValue = (String)mADProps[mPropName];
					}
				}
				if((mPropValue == String.Empty) ||(mPropValue == null ))   
				{
					throw new ApplicationException(" Property name ("+pPropertyName+")is Invalid or it does not contain any value ");
				}
				return (mPropValue);
			}
			catch(Exception e)
			{
				mERROR += (String)e.Message;
				return(String.Empty);
			}
		}
	
		public String GetConfigPropertyValue(String pPropertyName)
		{
			try
			{
				mMachineName = Environment.MachineName;
				String mPropName = pPropertyName.ToLower();
				String mPropValue = String.Empty;
		
				//verify for property cache either from Config or AD
				if(!IsConfigChecked)
				{
					if(mConfigProps == null)
					{
						mConfigProps = GetPropertyCacheFromConfig();
						IsConfigChecked = true;
					}
				}

				if(mConfigProps != null)
				{
					mPropValue = (String)mConfigProps[mPropName];
				}
				if((mPropValue == String.Empty) ||(mPropValue == null ))   
				{
					if(mADProps != null)
					{
						mPropValue = (String)mADProps[mPropName];
					}
				}
				if((mPropValue == String.Empty) ||(mPropValue == null ))   
				{
					throw new ApplicationException(" Property name ("+pPropertyName+")is Invalid or it does not contain any value ");
				}
				return (mPropValue);
			}
			catch(Exception e)
			{
				mERROR += (String)e.Message;
				return(String.Empty);
			}
		}
		public String GetError()
		{
			return(mERROR);
		}
		#endregion

		#region Private Methods
		private System.Collections.Hashtable GetPropertyCacheFromConfig()
		{
			//If property exists in the config file, add that property to Hashtable
			// otherwise don't add that property
			// If no property is available in the config, Then Hashtable with "null" value is returned.
			System.Collections.Hashtable ht = new System.Collections.Hashtable();
			System.Collections.Specialized.NameValueCollection NameValuePairs =  ConfigurationManager.AppSettings;
			for(int i=0; i < NameValuePairs.Count; i++)
			{
				if(NameValuePairs.GetValues(NameValuePairs.Keys[i]).Length > 0)
				{
					String theKey = String.Empty;
					try
					{
						theKey = NameValuePairs.Keys[i].ToLower().Split('.')[2];
					}
					catch
					{
					}
					if(!(theKey.Equals(String.Empty)))
						ht.Add(theKey, NameValuePairs.GetValues(NameValuePairs.Keys[i])[0]);
				}
			}
			return ht;
		}
		private String GetServerName()
		{
			try
			{
				System.Configuration.AppSettingsReader appSettingsReader = new System.Configuration.AppSettingsReader();
				String mServerName = (String)appSettingsReader.GetValue("gs.urbanism.ADServerName", Type.GetType("System.String") );
				return(mServerName);
			}
			catch(Exception e)
			{
				mERROR += (String)e.Message;
				return(String.Empty);
			}
		}
		#endregion
	}
}
