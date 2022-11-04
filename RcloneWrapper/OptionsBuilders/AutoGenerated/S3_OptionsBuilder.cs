using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System;
using System.ComponentModel;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Amazon S3 Compliant Storage Providers including AWS, Alibaba, Ceph, China Mobile, Cloudflare, ArvanCloud, Digital Ocean, Dreamhost, Huawei OBS, IBM COS, IDrive e2, IONOS Cloud, Lyve Cloud, Minio, Netease, RackCorp, Scaleway, SeaweedFS, StackPath, Storj, Tencent COS, Qiniu and Wasabi
    /// </summary>
    [FlagPrefix("s3")]
    public class S3_OptionsBuilder : Base_OptionsBuilder
    {
        public static class Endpoints
        {
            public const string ChinaMobile_Default = "eos-wuxi-1.cmecloud.cn";

            public const string ChinaMobile_East_China_Jinan = "eos-jinan-1.cmecloud.cn";

            public const string ChinaMobile_East_China_Hangzhou = "eos-ningbo-1.cmecloud.cn";

            public const string ChinaMobile_East_China_Shanghai_1 = "eos-shanghai-1.cmecloud.cn";

            public const string ChinaMobile_Central_China_Zhengzhou = "eos-zhengzhou-1.cmecloud.cn";

            public const string ChinaMobile_Central_China_Changsha_1 = "eos-hunan-1.cmecloud.cn";

            public const string ChinaMobile_Central_China_Changsha_2 = "eos-zhuzhou-1.cmecloud.cn";

            public const string ChinaMobile_South_China_Guangzhou_2 = "eos-guangzhou-1.cmecloud.cn";

            public const string ChinaMobile_South_China_Guangzhou_3 = "eos-dongguan-1.cmecloud.cn";

            public const string ChinaMobile_North_China_Beijing_1 = "eos-beijing-1.cmecloud.cn";

            public const string ChinaMobile_North_China_Beijing_2 = "eos-beijing-2.cmecloud.cn";

            public const string ChinaMobile_North_China_Beijing_3 = "eos-beijing-4.cmecloud.cn";

            public const string ChinaMobile_North_China_Huhehaote = "eos-huhehaote-1.cmecloud.cn";

            public const string ChinaMobile_SouthWest_China_Chengdu = "eos-chengdu-1.cmecloud.cn";

            public const string ChinaMobile_SouthWest_China_Chongqing = "eos-chongqing-1.cmecloud.cn";

            public const string ChinaMobile_SouthWest_China_Guiyang = "eos-guiyang-1.cmecloud.cn";

            public const string ChinaMobile_NorthWest_China_Xian = "eos-xian-1.cmecloud.cn";

            public const string ChinaMobile_Yunnan_China_Kunming = "eos-yunnan.cmecloud.cn";

            public const string ChinaMobile_Yunnan_China_Kunming_2 = "eos-yunnan-2.cmecloud.cn";

            public const string ChinaMobile_Tianjin_China_Tianjin = "eos-tianjin-1.cmecloud.cn";

            public const string ChinaMobile_Jilin_China_Changchun = "eos-jilin-1.cmecloud.cn";

            public const string ChinaMobile_Hubei_China_Xiangyan = "eos-hubei-1.cmecloud.cn";

            public const string ChinaMobile_Jiangxi_China_Nanchang = "eos-jiangxi-1.cmecloud.cn";

            public const string ChinaMobile_Gansu_China_Lanzhou = "eos-gansu-1.cmecloud.cn";

            public const string ChinaMobile_Shanxi_China_Taiyuan = "eos-shanxi-1.cmecloud.cn";

            public const string ChinaMobile_Liaoning_China_Shenyang = "eos-liaoning-1.cmecloud.cn";

            public const string ChinaMobile_Hebei_China_Shijiazhuang = "eos-hebei-1.cmecloud.cn";

            public const string ChinaMobile_Fujian_China_Xiamen = "eos-fujian-1.cmecloud.cn";

            public const string ChinaMobile_Guangxi_China_Nanning = "eos-guangxi-1.cmecloud.cn";

            public const string ChinaMobile_Anhui_China_Huainan = "eos-anhui-1.cmecloud.cn";

            public const string ArvanCloud_Default = "s3.ir-thr-at1.arvanstorage.com";

            public const string Arvancloud_Tabriz_Iran_Shahriar = "s3.ir-tbz-sh1.arvanstorage.com";

            public const string IBMCOS_US_Cross_Region = "s3.us.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_US_Cross_Region_Dallas = "s3.dal.us.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_US_Cross_Region_Washington_DC = "s3.wdc.us.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_US_Cross_Region_San_Jose = "s3.sjc.us.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_US_Cross_Region_Private = "s3.private.us.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_US_Cross_Region_Dallas_Private = "s3.private.dal.us.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_US_Cross_Region_Washington_DC_Private = "s3.private.wdc.us.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_US_Cross_Region_San_Jose_Private = "s3.private.sjc.us.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_US_Region_East = "s3.us-east.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_US_Region_East_Private = "s3.private.us-east.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_US_Region_South = "s3.us-south.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_US_Region_South_Private = "s3.private.us-south.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_EU_Cross_Region = "s3.eu.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_EU_Cross_Region_Frankfurt = "s3.fra.eu.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_EU_Cross_Region_Milan = "s3.mil.eu.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_EU_Cross_Region_Amsterdam = "s3.ams.eu.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_EU_Cross_Region_Private = "s3.private.eu.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_EU_Cross_Region_Frankfurt_Private = "s3.private.fra.eu.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_EU_Cross_Region_Milan_Private = "s3.private.mil.eu.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_EU_Cross_Region_Amsterdam_Private = "s3.private.ams.eu.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Great_Britain = "s3.eu-gb.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Great_Britain_Private = "s3.private.eu-gb.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_EU_Region_DE = "s3.eu-de.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_EU_Region_DE_Private = "s3.private.eu-de.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Apac_Cross_Regional = "s3.ap.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Apac_Cross_Regional_Tokyo = "s3.tok.ap.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Apac_Cross_Regional_Hongkong = "s3.hkg.ap.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Apac_Cross_Regional_Seoul = "s3.seo.ap.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Apac_Cross_Regional_Private = "s3.private.ap.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Apac_Cross_Regional_Tokyo_Private = "s3.private.tok.ap.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Apac_Cross_Regional_Hongkong_Private = "s3.private.hkg.ap.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Apac_Cross_Regional_Seoul_Private = "s3.private.seo.ap.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Apac_Region_Japan = "s3.jp-tok.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Apac_Region_Japan_Private = "s3.private.jp-tok.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Apac_Region_Australia = "s3.au-syd.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Apac_Region_Australia_Private = "s3.private.au-syd.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Amsterdam_Single_Site = "s3.ams03.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Amsterdam_Single_Site_Private = "s3.private.ams03.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Chennai_Single_Site = "s3.che01.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Chennai_Single_Site_Private = "s3.private.che01.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Melbourne_Single_Site = "s3.mel01.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Melbourne_Single_Site_Private = "s3.private.mel01.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Oslo_Single_Site = "s3.osl01.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Oslo_Single_Site_Private = "s3.private.osl01.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Toronto_Single_Site = "s3.tor01.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Toronto_Single_Site_Private = "s3.private.tor01.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Seoul_Single_Site = "s3.seo01.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Seoul_Single_Site_Private = "s3.private.seo01.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Montreal_Single_Site = "s3.mon01.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Montreal_Single_Site_Private = "s3.private.mon01.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Mexico_Single_Site = "s3.mex01.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Mexico_Single_Site_Private = "s3.private.mex01.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_San_Jose_Single_Site = "s3.sjc04.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_San_Jose_Single_Site_Private = "s3.private.sjc04.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Milan_Single_Site = "s3.mil01.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Milan_Single_Site_Private = "s3.private.mil01.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Hong_Kong_Single_Site = "s3.hkg02.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Hong_Kong_Single_Site_Private = "s3.private.hkg02.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Paris_Single_Site = "s3.par01.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Paris_Single_Site_Private = "s3.private.par01.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Singapore_Single_Site = "s3.sng01.cloud-object-storage.appdomain.cloud";

            public const string IBMCOS_Singapore_Single_Site_Private = "s3.private.sng01.cloud-object-storage.appdomain.cloud";

            public const string IONOS_Frankfurt_Germany = "s3-eu-central-1.ionoscloud.com";

            public const string IONOS_Berlin_Germany = "s3-eu-central-2.ionoscloud.com";

            public const string IONOS_Logrono_Spain = "s3-eu-south-2.ionoscloud.com";

            public const string Alibaba_Global_Accelerate = "oss-accelerate.aliyuncs.com";

            public const string Alibaba_Global_Accelerate_Outside_Mainland_China = "oss-accelerate-overseas.aliyuncs.com";

            public const string Alibaba_East_China_1_Hangzhou = "oss-cn-hangzhou.aliyuncs.com";

            public const string Alibaba_East_China_2_Shanghai = "oss-cn-shanghai.aliyuncs.com";

            public const string Alibaba_North_China_1_Qingdao = "oss-cn-qingdao.aliyuncs.com";

            public const string Alibaba_North_China_2_Beijing = "oss-cn-beijing.aliyuncs.com";

            public const string Alibaba_North_China_3_Zhangjiakou = "oss-cn-zhangjiakou.aliyuncs.com";

            public const string Alibaba_North_China_5_Hohhot = "oss-cn-huhehaote.aliyuncs.com";

            public const string Alibaba_North_China_6_Ulanqab = "oss-cn-wulanchabu.aliyuncs.com";

            public const string Alibaba_South_China_1_Shenzhen = "oss-cn-shenzhen.aliyuncs.com";

            public const string Alibaba_South_China_2_Heyuan = "oss-cn-heyuan.aliyuncs.com";

            public const string Alibaba_South_China_3_Guangzhou = "oss-cn-guangzhou.aliyuncs.com";

            public const string Alibaba_West_China_1_Chengdu = "oss-cn-chengdu.aliyuncs.com";

            public const string Alibaba_Hong_Kong_Hong_Kong = "oss-cn-hongkong.aliyuncs.com";

            public const string Alibaba_US_West_1_Silicon_Valley = "oss-us-west-1.aliyuncs.com";

            public const string Alibaba_US_East_1_Virginia = "oss-us-east-1.aliyuncs.com";

            public const string Alibaba_SouthEast_Asia_SouthEast_1_Singapore = "oss-ap-southeast-1.aliyuncs.com";

            public const string Alibaba_Asia_Pacific_SouthEast_2_Sydney = "oss-ap-southeast-2.aliyuncs.com";

            public const string Alibaba_SouthEast_Asia_SouthEast_3_Kuala_Lumpur = "oss-ap-southeast-3.aliyuncs.com";

            public const string Alibaba_Asia_Pacific_SouthEast_5_Jakarta = "oss-ap-southeast-5.aliyuncs.com";

            public const string Alibaba_Asia_Pacific_NorthEast_1_Japan = "oss-ap-northeast-1.aliyuncs.com";

            public const string Alibaba_Asia_Pacific_South_1_Mumbai = "oss-ap-south-1.aliyuncs.com";

            public const string Alibaba_Central_Europe_1_Frankfurt = "oss-eu-central-1.aliyuncs.com";

            public const string Alibaba_West_Europe_London = "oss-eu-west-1.aliyuncs.com";

            public const string Alibaba_Middle_East_1_Dubai = "oss-me-east-1.aliyuncs.com";

            public const string HuaweiOBS_AF_Johannesburg = "obs.af-south-1.myhuaweicloud.com";

            public const string HuaweiOBS_AP_Bangkok = "obs.ap-southeast-2.myhuaweicloud.com";

            public const string HuaweiOBS_AP_Singapore = "obs.ap-southeast-3.myhuaweicloud.com";

            public const string HuaweiOBS_CN_East_Shanghai1 = "obs.cn-east-3.myhuaweicloud.com";

            public const string HuaweiOBS_CN_East_Shanghai2 = "obs.cn-east-2.myhuaweicloud.com";

            public const string HuaweiOBS_CN_North_Beijing1 = "obs.cn-north-1.myhuaweicloud.com";

            public const string HuaweiOBS_CN_North_Beijing4 = "obs.cn-north-4.myhuaweicloud.com";

            public const string HuaweiOBS_CN_South_Guangzhou = "obs.cn-south-1.myhuaweicloud.com";

            public const string HuaweiOBS_CN_Hong_Kong = "obs.ap-southeast-1.myhuaweicloud.com";

            public const string HuaweiOBS_LA_Buenos_Aires1 = "obs.sa-argentina-1.myhuaweicloud.com";

            public const string HuaweiOBS_LA_Lima1 = "obs.sa-peru-1.myhuaweicloud.com";

            public const string HuaweiOBS_LA_Mexico_City1 = "obs.na-mexico-1.myhuaweicloud.com";

            public const string HuaweiOBS_LA_Santiago2 = "obs.sa-chile-1.myhuaweicloud.com";

            public const string HuaweiOBS_LA_Sao_Paulo1 = "obs.sa-brazil-1.myhuaweicloud.com";

            public const string HuaweiOBS_RU_Moscow2 = "obs.ru-northwest-2.myhuaweicloud.com";

            public const string Scaleway_Amsterdam = "s3.nl-ams.scw.cloud";

            public const string Scaleway_Paris = "s3.fr-par.scw.cloud";

            public const string Scaleway_Warsaw = "s3.pl-waw.scw.cloud";

            public const string Stackpath_US_East = "s3.us-east-2.stackpathstorage.com";

            public const string Stackpath_US_West = "s3.us-west-1.stackpathstorage.com";

            public const string Stackpath_EU = "s3.eu-central-1.stackpathstorage.com";

            public const string Storj_EU1_Shared_Gateway = "gateway.eu1.storjshare.io";

            public const string Storj_US1_Shared_Gateway = "gateway.us1.storjshare.io";

            public const string Storj_Asia_Pacific_Shared_Gateway = "gateway.ap1.storjshare.io";

            public const string TencentCOS_Beijing_Region = "cos.ap-beijing.myqcloud.com";

            public const string TencentCOS_Shanghai_Region = "cos.ap-shanghai.myqcloud.com";

            public const string TencentCOS_Guangzhou_Region = "cos.ap-guangzhou.myqcloud.com";

            public const string TencentCOS_Chengdu_Region = "cos.ap-chengdu.myqcloud.com";

            public const string TencentCOS_Chongqing_Region = "cos.ap-chongqing.myqcloud.com";

            public const string TencentCOS_Hong_Kong_China_Region = "cos.ap-hongkong.myqcloud.com";

            public const string TencentCOS_Singapore_Region = "cos.ap-singapore.myqcloud.com";

            public const string TencentCOS_Mumbai_Region = "cos.ap-mumbai.myqcloud.com";

            public const string TencentCOS_Seoul_Region = "cos.ap-seoul.myqcloud.com";

            public const string TencentCOS_Bangkok_Region = "cos.ap-bangkok.myqcloud.com";

            public const string TencentCOS_Tokyo_Region = "cos.ap-tokyo.myqcloud.com";

            public const string TencentCOS_Silicon_Valley_Region = "cos.na-siliconvalley.myqcloud.com";

            public const string TencentCOS_Virginia_Region = "cos.na-ashburn.myqcloud.com";

            public const string TencentCOS_Toronto_Region = "cos.na-toronto.myqcloud.com";

            public const string TencentCOS_Frankfurt_Region = "cos.eu-frankfurt.myqcloud.com";

            public const string TencentCOS_Moscow_Region = "cos.eu-moscow.myqcloud.com";

            public const string TencentCOS_Use_Tencent_COS_Accelerate = "cos.accelerate.myqcloud.com";

            public const string TencentCOS_Nanjing_Region = "cos.ap-nanjing.myqcloud.com";

            public const string Rackcorp_Global_Anycast = "s3.rackcorp.com";

            public const string Rackcorp_Australia_Anycast = "au.s3.rackcorp.com";

            public const string Rackcorp_Sydney_Australia = "au-nsw.s3.rackcorp.com";

            public const string Rackcorp_Brisbane_Australia = "au-qld.s3.rackcorp.com";

            public const string Rackcorp_Melbourne_Australia = "au-vic.s3.rackcorp.com";

            public const string Rackcorp_Perth_Australia = "au-wa.s3.rackcorp.com";

            public const string Rackcorp_Manila_Philippines = "ph.s3.rackcorp.com";

            public const string Rackcorp_Bangkok_Thailand = "th.s3.rackcorp.com";

            public const string Rackcorp_HK_Hong_Kong = "hk.s3.rackcorp.com";

            public const string Rackcorp_Ulaanbaatar_Mongolia = "mn.s3.rackcorp.com";

            public const string Rackcorp_Bishkek_Kyrgyzstan = "kg.s3.rackcorp.com";

            public const string Rackcorp_Jakarta_Indonesia = "id.s3.rackcorp.com";

            public const string Rackcorp_Tokyo_Japan = "jp.s3.rackcorp.com";

            public const string Rackcorp_SG_Singapore = "sg.s3.rackcorp.com";

            public const string Rackcorp_Frankfurt_Germany = "de.s3.rackcorp.com";

            public const string Rackcorp_USA_Anycast = "us.s3.rackcorp.com";

            public const string Rackcorp_New_York_USA = "us-east-1.s3.rackcorp.com";

            public const string Rackcorp_Freemont_USA = "us-west-1.s3.rackcorp.com";

            public const string Rackcorp_Auckland_New_Zealand = "nz.s3.rackcorp.com";

            public const string Qiniu_East_China_1 = "s3-cn-east-1.qiniucs.com";

            public const string Qiniu_East_China_2 = "s3-cn-east-2.qiniucs.com";

            public const string Qiniu_North_China_1 = "s3-cn-north-1.qiniucs.com";

            public const string Qiniu_South_China_1 = "s3-cn-south-1.qiniucs.com";

            public const string Qiniu_North_America_1 = "s3-us-north-1.qiniucs.com";

            public const string Qiniu_SouthEast_Asia_1 = "s3-ap-southeast-1.qiniucs.com";

            public const string Qiniu_NorthEast_Asia_1 = "s3-ap-northeast-1.qiniucs.com";

            public const string Dreamhost_Dream_Objects = "objects-us-east-1.dream.io";

            public const string DigitalOcean_Spaces_New_York_3 = "nyc3.digitaloceanspaces.com";

            public const string DigitalOcean_Spaces_Amsterdam_3 = "ams3.digitaloceanspaces.com";

            public const string DigitalOcean_Spaces_Singapore_1 = "sgp1.digitaloceanspaces.com";

            public const string SeaweedFS_S3_Localhost = "localhost:8333";

            public const string Lyvecloud_US_East_1_Virginia = "s3.us-east-1.lyvecloud.seagate.com";

            public const string Lyvecloud_US_West_1_California = "s3.us-west-1.lyvecloud.seagate.com";

            public const string Lyvecloud_AP_SouthEast_1_Singapore = "s3.ap-southeast-1.lyvecloud.seagate.com";

            public const string Wasabi_US_East = "s3.wasabisys.com";

            public const string Wasabi_US_West = "s3.us-west-1.wasabisys.com";

            public const string Wasabi_EU_Central = "s3.eu-central-1.wasabisys.com";

            public const string Wasabi_AP_NorthEast_1_Tokyo = "s3.ap-northeast-1.wasabisys.com";

            public const string Wasabi_AP_NorthEast_2_Osaka = "s3.ap-northeast-2.wasabisys.com";

            public const string Arvancloud_Tehran_Iran_Asiatech = "s3.ir-thr-at1.arvanstorage.com";

        }


        public static class LocationConstraints
        {
            public const string AWS = "";

            public const string AWS_US_East_2 = "us-east-2";

            public const string AWS_US_West_1 = "us-west-1";

            public const string AWS_US_West_2 = "us-west-2";

            public const string AWS_CA_Central_1 = "ca-central-1";

            public const string AWS_EU_West_1 = "eu-west-1";

            public const string AWS_EU_West_2 = "eu-west-2";

            public const string AWS_EU_West_3 = "eu-west-3";

            public const string AWS_EU_North_1 = "eu-north-1";

            public const string AWS_EU_South_1 = "eu-south-1";

            public const string AWS_EU = "EU";

            public const string AWS_AP_SouthEast_1 = "ap-southeast-1";

            public const string AWS_AP_SouthEast_2 = "ap-southeast-2";

            public const string AWS_AP_NorthEast_1 = "ap-northeast-1";

            public const string AWS_AP_NorthEast_2 = "ap-northeast-2";

            public const string AWS_AP_NorthEast_3 = "ap-northeast-3";

            public const string AWS_AP_South_1 = "ap-south-1";

            public const string AWS_AP_East_1 = "ap-east-1";

            public const string AWS_SA_East_1 = "sa-east-1";

            public const string AWS_ME_South_1 = "me-south-1";

            public const string AWS_AF_South_1 = "af-south-1";

            public const string AWS_CN_North_1 = "cn-north-1";

            public const string AWS_CN_NorthWest_1 = "cn-northwest-1";

            public const string AWS_US_Gov_East_1 = "us-gov-east-1";

            public const string AWS_US_Gov_West_1 = "us-gov-west-1";

            public const string ChinaMobile_Wuxi1 = "wuxi1";

            public const string ChinaMobile_Jinan1 = "jinan1";

            public const string ChinaMobile_Ningbo1 = "ningbo1";

            public const string ChinaMobile_Shanghai1 = "shanghai1";

            public const string ChinaMobile_Zhengzhou1 = "zhengzhou1";

            public const string ChinaMobile_Hunan1 = "hunan1";

            public const string ChinaMobile_Zhuzhou1 = "zhuzhou1";

            public const string ChinaMobile_Guangzhou1 = "guangzhou1";

            public const string ChinaMobile_Dongguan1 = "dongguan1";

            public const string ChinaMobile_Beijing1 = "beijing1";

            public const string ChinaMobile_Beijing2 = "beijing2";

            public const string ChinaMobile_Beijing4 = "beijing4";

            public const string ChinaMobile_Huhehaote1 = "huhehaote1";

            public const string ChinaMobile_Chengdu1 = "chengdu1";

            public const string ChinaMobile_Chongqing1 = "chongqing1";

            public const string ChinaMobile_Guiyang1 = "guiyang1";

            public const string ChinaMobile_Xian1 = "xian1";

            public const string ChinaMobile_Yunnan = "yunnan";

            public const string ChinaMobile_Yunnan2 = "yunnan2";

            public const string ChinaMobile_Tianjin1 = "tianjin1";

            public const string ChinaMobile_Jilin1 = "jilin1";

            public const string ChinaMobile_Hubei1 = "hubei1";

            public const string ChinaMobile_Jiangxi1 = "jiangxi1";

            public const string ChinaMobile_Gansu1 = "gansu1";

            public const string ChinaMobile_Shanxi1 = "shanxi1";

            public const string ChinaMobile_Liaoning1 = "liaoning1";

            public const string ChinaMobile_Hebei1 = "hebei1";

            public const string ChinaMobile_Fujian1 = "fujian1";

            public const string ChinaMobile_Guangxi1 = "guangxi1";

            public const string ChinaMobile_Anhui1 = "anhui1";

            public const string ArvanCloud_Ir_Thr_At1 = "ir-thr-at1";

            public const string ArvanCloud_Ir_Tbz_Sh1 = "ir-tbz-sh1";

            public const string IBMCOS_US_Standard = "us-standard";

            public const string IBMCOS_US_Vault = "us-vault";

            public const string IBMCOS_US_Cold = "us-cold";

            public const string IBMCOS_US_Flex = "us-flex";

            public const string IBMCOS_US_East_Standard = "us-east-standard";

            public const string IBMCOS_US_East_Vault = "us-east-vault";

            public const string IBMCOS_US_East_Cold = "us-east-cold";

            public const string IBMCOS_US_East_Flex = "us-east-flex";

            public const string IBMCOS_US_South_Standard = "us-south-standard";

            public const string IBMCOS_US_South_Vault = "us-south-vault";

            public const string IBMCOS_US_South_Cold = "us-south-cold";

            public const string IBMCOS_US_South_Flex = "us-south-flex";

            public const string IBMCOS_EU_Standard = "eu-standard";

            public const string IBMCOS_EU_Vault = "eu-vault";

            public const string IBMCOS_EU_Cold = "eu-cold";

            public const string IBMCOS_EU_Flex = "eu-flex";

            public const string IBMCOS_EU_GB_Standard = "eu-gb-standard";

            public const string IBMCOS_EU_GB_Vault = "eu-gb-vault";

            public const string IBMCOS_EU_GB_Cold = "eu-gb-cold";

            public const string IBMCOS_EU_GB_Flex = "eu-gb-flex";

            public const string IBMCOS_AP_Standard = "ap-standard";

            public const string IBMCOS_AP_Vault = "ap-vault";

            public const string IBMCOS_AP_Cold = "ap-cold";

            public const string IBMCOS_AP_Flex = "ap-flex";

            public const string IBMCOS_Mel01_Standard = "mel01-standard";

            public const string IBMCOS_Mel01_Vault = "mel01-vault";

            public const string IBMCOS_Mel01_Cold = "mel01-cold";

            public const string IBMCOS_Mel01_Flex = "mel01-flex";

            public const string IBMCOS_Tor01_Standard = "tor01-standard";

            public const string IBMCOS_Tor01_Vault = "tor01-vault";

            public const string IBMCOS_Tor01_Cold = "tor01-cold";

            public const string IBMCOS_Tor01_Flex = "tor01-flex";

            public const string RackCorp_Global = "global";

            public const string RackCorp_AU = "au";

            public const string RackCorp_AU_Nsw = "au-nsw";

            public const string RackCorp_AU_Qld = "au-qld";

            public const string RackCorp_AU_Vic = "au-vic";

            public const string RackCorp_AU_Wa = "au-wa";

            public const string RackCorp_PH = "ph";

            public const string RackCorp_TH = "th";

            public const string RackCorp_HK = "hk";

            public const string RackCorp_MN = "mn";

            public const string RackCorp_KG = "kg";

            public const string RackCorp_ID = "id";

            public const string RackCorp_JP = "jp";

            public const string RackCorp_SG = "sg";

            public const string RackCorp_DE = "de";

            public const string RackCorp_US = "us";

            public const string RackCorp_US_East_1 = "us-east-1";

            public const string RackCorp_US_West_1 = "us-west-1";

            public const string RackCorp_NZ = "nz";

            public const string Qiniu_CN_East_1 = "cn-east-1";

            public const string Qiniu_CN_East_2 = "cn-east-2";

            public const string Qiniu_CN_North_1 = "cn-north-1";

            public const string Qiniu_CN_South_1 = "cn-south-1";

            public const string Qiniu_US_North_1 = "us-north-1";

            public const string Qiniu_AP_SouthEast_1 = "ap-southeast-1";

            public const string Qiniu_AP_NorthEast_1 = "ap-northeast-1";

        }


        public static class Regions
        {
            public const string AWS_US_East_1 = "us-east-1";

            public const string AWS_US_East_2 = "us-east-2";

            public const string AWS_US_West_1 = "us-west-1";

            public const string AWS_US_West_2 = "us-west-2";

            public const string AWS_CA_Central_1 = "ca-central-1";

            public const string AWS_EU_West_1 = "eu-west-1";

            public const string AWS_EU_West_2 = "eu-west-2";

            public const string AWS_EU_West_3 = "eu-west-3";

            public const string AWS_EU_North_1 = "eu-north-1";

            public const string AWS_EU_South_1 = "eu-south-1";

            public const string AWS_EU_Central_1 = "eu-central-1";

            public const string AWS_AP_SouthEast_1 = "ap-southeast-1";

            public const string AWS_AP_SouthEast_2 = "ap-southeast-2";

            public const string AWS_AP_NorthEast_1 = "ap-northeast-1";

            public const string AWS_AP_NorthEast_2 = "ap-northeast-2";

            public const string AWS_AP_NorthEast_3 = "ap-northeast-3";

            public const string AWS_AP_South_1 = "ap-south-1";

            public const string AWS_AP_East_1 = "ap-east-1";

            public const string AWS_SA_East_1 = "sa-east-1";

            public const string AWS_ME_South_1 = "me-south-1";

            public const string AWS_AF_South_1 = "af-south-1";

            public const string AWS_CN_North_1 = "cn-north-1";

            public const string AWS_CN_NorthWest_1 = "cn-northwest-1";

            public const string AWS_US_Gov_East_1 = "us-gov-east-1";

            public const string AWS_US_Gov_West_1 = "us-gov-west-1";

            public const string RackCorp_Global = "global";

            public const string RackCorp_AU = "au";

            public const string RackCorp_AU_Nsw = "au-nsw";

            public const string RackCorp_AU_Qld = "au-qld";

            public const string RackCorp_AU_Vic = "au-vic";

            public const string RackCorp_AU_Wa = "au-wa";

            public const string RackCorp_PH = "ph";

            public const string RackCorp_TH = "th";

            public const string RackCorp_HK = "hk";

            public const string RackCorp_MN = "mn";

            public const string RackCorp_KG = "kg";

            public const string RackCorp_ID = "id";

            public const string RackCorp_JP = "jp";

            public const string RackCorp_SG = "sg";

            public const string RackCorp_DE = "de";

            public const string RackCorp_US = "us";

            public const string RackCorp_US_East_1 = "us-east-1";

            public const string RackCorp_US_West_1 = "us-west-1";

            public const string RackCorp_NZ = "nz";

            public const string Scaleway_NL_Ams = "nl-ams";

            public const string Scaleway_FR_Par = "fr-par";

            public const string Scaleway_PL_Waw = "pl-waw";

            public const string HuaweiOBS_AF_South_1 = "af-south-1";

            public const string HuaweiOBS_AP_SouthEast_2 = "ap-southeast-2";

            public const string HuaweiOBS_AP_SouthEast_3 = "ap-southeast-3";

            public const string HuaweiOBS_CN_East_3 = "cn-east-3";

            public const string HuaweiOBS_CN_East_2 = "cn-east-2";

            public const string HuaweiOBS_CN_North_1 = "cn-north-1";

            public const string HuaweiOBS_CN_North_4 = "cn-north-4";

            public const string HuaweiOBS_CN_South_1 = "cn-south-1";

            public const string HuaweiOBS_AP_SouthEast_1 = "ap-southeast-1";

            public const string HuaweiOBS_SA_Argentina_1 = "sa-argentina-1";

            public const string HuaweiOBS_SA_Peru_1 = "sa-peru-1";

            public const string HuaweiOBS_Na_Mexico_1 = "na-mexico-1";

            public const string HuaweiOBS_SA_Chile_1 = "sa-chile-1";

            public const string HuaweiOBS_SA_Brazil_1 = "sa-brazil-1";

            public const string HuaweiOBS_RU_NorthWest_2 = "ru-northwest-2";

            public const string Cloudflare_Auto = "auto";

            public const string Qiniu_CN_East_1 = "cn-east-1";

            public const string Qiniu_CN_East_2 = "cn-east-2";

            public const string Qiniu_CN_North_1 = "cn-north-1";

            public const string Qiniu_CN_South_1 = "cn-south-1";

            public const string Qiniu_US_North_1 = "us-north-1";

            public const string Qiniu_AP_SouthEast_1 = "ap-southeast-1";

            public const string Qiniu_AP_NorthEast_1 = "ap-northeast-1";

            public const string IONOS_DE = "de";

            public const string IONOS_EU_Central_2 = "eu-central-2";

            public const string IONOS_EU_South_2 = "eu-south-2";

        }


        public static class StorageClasses
        {
            public const string AWS_Default = "";

            public const string AWS_STANDARD = "STANDARD";

            public const string AWS_REDUCED_REDUNDANCY = "REDUCED_REDUNDANCY";

            public const string AWS_STANDARD_IA = "STANDARD_IA";

            public const string AWS_ONEZONE_IA = "ONEZONE_IA";

            public const string AWS_GLACIER = "GLACIER";

            public const string AWS_DEEP_ARCHIVE = "DEEP_ARCHIVE";

            public const string AWS_INTELLIGENT_TIERING = "INTELLIGENT_TIERING";

            public const string AWS_GLACIER_IR = "GLACIER_IR";

            public const string Alibaba_Default = "";

            public const string Alibaba_STANDARD = "STANDARD";

            public const string Alibaba_GLACIER = "GLACIER";

            public const string Alibaba_STANDARD_IA = "STANDARD_IA";

            public const string ChinaMobile_Default = "";

            public const string ChinaMobile_STANDARD = "STANDARD";

            public const string ChinaMobile_GLACIER = "GLACIER";

            public const string ChinaMobile_STANDARD_IA = "STANDARD_IA";

            public const string ArvanCloud_STANDARD = "STANDARD";

            public const string TencentCOS_Default = "";

            public const string TencentCOS_STANDARD = "STANDARD";

            public const string TencentCOS_ARCHIVE = "ARCHIVE";

            public const string TencentCOS_STANDARD_IA = "STANDARD_IA";

            public const string Scaleway_Default = "";

            public const string Scaleway_STANDARD = "STANDARD";

            public const string Scaleway_GLACIER = "GLACIER";

            public const string Qiniu_STANDARD = "STANDARD";

            public const string Qiniu_LINE = "LINE";

            public const string Qiniu_GLACIER = "GLACIER";

            public const string Qiniu_DEEP_ARCHIVE = "DEEP_ARCHIVE";

        }


        public enum Acls
        {
            /// <summary>
            /// Owner gets FULL_CONTROL. No one else has access rights (default).
            /// </summary>
            [Description("private")]
            Private,

            /// <summary>
            /// Owner gets FULL_CONTROL. The AllUsers group gets READ access.
            /// </summary>
            [Description("public-read")]
            Public_Read,

            /// <summary>
            /// Owner gets FULL_CONTROL. The AllUsers group gets READ and WRITE access. Granting this on a bucket is generally not recommended.
            /// </summary>
            [Description("public-read-write")]
            Public_Read_Write,

            /// <summary>
            /// Owner gets FULL_CONTROL. The AuthenticatedUsers group gets READ access.
            /// </summary>
            [Description("authenticated-read")]
            Authenticated_Read,

            /// <summary>
            /// Object owner gets FULL_CONTROL. Bucket owner gets READ access. If you specify this canned ACL when creating a bucket, Amazon S3 ignores it.
            /// </summary>
            [Description("bucket-owner-read")]
            Bucket_Owner_Read,

            /// <summary>
            /// Both the object owner and the bucket owner get FULL_CONTROL over the object. If you specify this canned ACL when creating a bucket, Amazon S3 ignores it.
            /// </summary>
            [Description("bucket-owner-full-control")]
            Bucket_Owner_Full_Control,

            /// <summary>
            /// Owner gets FULL_CONTROL. No one else has access rights (default). This acl is available on IBM Cloud (Infra), IBM Cloud (Storage), On-Premise COS.
            /// </summary>
            [Description("private_ibm_cos")]
            Private_IBM_COS,

            /// <summary>
            /// Owner gets FULL_CONTROL. The AllUsers group gets READ access. This acl is available on IBM Cloud (Infra), IBM Cloud (Storage), On-Premise IBM COS.
            /// </summary>
            [Description("public-read_ibm_cos")]
            Public_Read_IBM_COS,

            /// <summary>
            /// Owner gets FULL_CONTROL. The AllUsers group gets READ and WRITE access. This acl is available on IBM Cloud (Infra), On-Premise IBM COS.
            /// </summary>
            [Description("public-read-write_ibm_cos")]
            Public_Read_Write_IBM_COS,

            /// <summary>
            /// Owner gets FULL_CONTROL. The AuthenticatedUsers group gets READ access. Not supported on Buckets. This acl is available on IBM Cloud (Infra) and On-Premise IBM COS.
            /// </summary>
            [Description("authenticated-read_ibm_cos")]
            Authenticated_Read_IBM_COS,

        }


        public enum BucketAcls
        {
            /// <summary>
            /// Owner gets FULL_CONTROL. No one else has access rights (default).
            /// </summary>
            [Description("private")]
            Private,

            /// <summary>
            /// Owner gets FULL_CONTROL. The AllUsers group gets READ access.
            /// </summary>
            [Description("public-read")]
            Public_Read,

            /// <summary>
            /// Owner gets FULL_CONTROL. The AllUsers group gets READ and WRITE access. Granting this on a bucket is generally not recommended.
            /// </summary>
            [Description("public-read-write")]
            Public_Read_Write,

            /// <summary>
            /// Owner gets FULL_CONTROL. The AuthenticatedUsers group gets READ access.
            /// </summary>
            [Description("authenticated-read")]
            Authenticated_Read,

        }


        public enum Providers
        {
            /// <summary>
            /// Amazon Web Services (AWS) S3
            /// </summary>
            [Description("AWS")]
            AWS,

            /// <summary>
            /// Alibaba Cloud Object Storage System (OSS) formerly Aliyun
            /// </summary>
            [Description("Alibaba")]
            Alibaba,

            /// <summary>
            /// Ceph Object Storage
            /// </summary>
            [Description("Ceph")]
            Ceph,

            /// <summary>
            /// China Mobile Ecloud Elastic Object Storage (EOS)
            /// </summary>
            [Description("ChinaMobile")]
            ChinaMobile,

            /// <summary>
            /// Cloudflare R2 Storage
            /// </summary>
            [Description("Cloudflare")]
            Cloudflare,

            /// <summary>
            /// Arvan Cloud Object Storage (AOS)
            /// </summary>
            [Description("ArvanCloud")]
            ArvanCloud,

            /// <summary>
            /// Digital Ocean Spaces
            /// </summary>
            [Description("DigitalOcean")]
            DigitalOcean,

            /// <summary>
            /// Dreamhost DreamObjects
            /// </summary>
            [Description("Dreamhost")]
            Dreamhost,

            /// <summary>
            /// Huawei Object Storage Service
            /// </summary>
            [Description("HuaweiOBS")]
            HuaweiOBS,

            /// <summary>
            /// IBM COS S3
            /// </summary>
            [Description("IBMCOS")]
            IBMCOS,

            /// <summary>
            /// IDrive e2
            /// </summary>
            [Description("IDrive")]
            IDrive,

            /// <summary>
            /// IONOS Cloud
            /// </summary>
            [Description("IONOS")]
            IONOS,

            /// <summary>
            /// Seagate Lyve Cloud
            /// </summary>
            [Description("LyveCloud")]
            LyveCloud,

            /// <summary>
            /// Minio Object Storage
            /// </summary>
            [Description("Minio")]
            Minio,

            /// <summary>
            /// Netease Object Storage (NOS)
            /// </summary>
            [Description("Netease")]
            Netease,

            /// <summary>
            /// RackCorp Object Storage
            /// </summary>
            [Description("RackCorp")]
            RackCorp,

            /// <summary>
            /// Scaleway Object Storage
            /// </summary>
            [Description("Scaleway")]
            Scaleway,

            /// <summary>
            /// SeaweedFS S3
            /// </summary>
            [Description("SeaweedFS")]
            SeaweedFS,

            /// <summary>
            /// StackPath Object Storage
            /// </summary>
            [Description("StackPath")]
            StackPath,

            /// <summary>
            /// Storj (S3 Compatible Gateway)
            /// </summary>
            [Description("Storj")]
            Storj,

            /// <summary>
            /// Tencent Cloud Object Storage (COS)
            /// </summary>
            [Description("TencentCOS")]
            TencentCOS,

            /// <summary>
            /// Wasabi Object Storage
            /// </summary>
            [Description("Wasabi")]
            Wasabi,

            /// <summary>
            /// Qiniu Object Storage (Kodo)
            /// </summary>
            [Description("Qiniu")]
            Qiniu,

            /// <summary>
            /// Any other S3 compatible provider
            /// </summary>
            [Description("Other")]
            Other,

        }


        /// <summary>
        /// AWS Access Key ID
        /// </summary>
        [StringFlag("access-key-id")]
        public string AccessKeyId { get; set; }


        /// <summary>
        /// Canned ACL used when creating buckets and storing or copying objects
        /// </summary>
        [SingleEnumFlag("acl", (int)Acls.Private)]
        public Acls? Acl { get; set; }


        /// <summary>
        /// Canned ACL used when creating buckets
        /// </summary>
        [SingleEnumFlag("bucket-acl", (int)BucketAcls.Private)]
        public BucketAcls? BucketAcl { get; set; }


        /// <summary>
        /// Chunk size to use for uploading (default 5Mi)
        /// </summary>
        [SizeSuffixFlag("chunk-size", "5M")]
        public SizeSuffix ChunkSize { get; set; }


        /// <summary>
        /// Cutoff for switching to multipart copy (default 4.656Gi)
        /// </summary>
        [SizeSuffixFlag("copy-cutoff", "4.656G")]
        public SizeSuffix CopyCutoff { get; set; }


        /// <summary>
        /// If set this will decompress gzip encoded objects
        /// </summary>
        [BoolFlag("decompress")]
        public bool Decompress { get; set; }


        /// <summary>
        /// Don&#39;t store MD5 checksum with object metadata
        /// </summary>
        [BoolFlag("disable-checksum")]
        public bool DisableChecksum { get; set; }


        /// <summary>
        /// Disable usage of http2 for S3 backends
        /// </summary>
        [BoolFlag("disable-http2")]
        public bool DisableHttp2 { get; set; }


        /// <summary>
        /// Custom endpoint for downloads
        /// </summary>
        [StringFlag("download-url")]
        public string DownloadUrl { get; set; }


        /// <summary>
        /// The encoding for the backend (default Slash,InvalidUtf8,Dot)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.InvalidUtf8 | EncodingFlags.Dot))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Endpoint for S3 API
        /// </summary>
        [StringFlag("endpoint")]
        public string Endpoint { get; set; }


        /// <summary>
        /// Get AWS credentials from runtime (environment variables or EC2/ECS meta data if no env vars)
        /// </summary>
        [BoolFlag("env-auth")]
        public bool EnvAuth { get; set; }


        /// <summary>
        /// If true use path style access if false use virtual hosted style (default true)
        /// </summary>
        [BoolFlag("force-path-style", true)]
        public bool ForcePathStyle { get; set; } = true;


        /// <summary>
        /// If true avoid calling abort upload on a failure, leaving all successfully uploaded parts on S3 for manual recovery
        /// </summary>
        [BoolFlag("leave-parts-on-error")]
        public bool LeavePartsOnError { get; set; }


        /// <summary>
        /// Size of listing chunk (response list for each ListObject S3 request) (default 1000)
        /// </summary>
        [UintFlag("list-chunk", 1000, 1)]
        public uint? ListChunk { get; set; }


        /// <summary>
        /// Whether to url encode listings: true/false/unset (default unset)
        /// </summary>
        [TristateFlag("list-url-encode")]
        public bool? ListUrlEncode { get; set; }


        /// <summary>
        /// Version of ListObjects to use: 1,2 or 0 for auto
        /// </summary>
        [UintFlag("port", 2, 0, 2)]
        public uint? ListVersion { get; set; }


        /// <summary>
        /// Location constraint - must be set to match the Region
        /// </summary>
        [StringFlag("location-constraint")]
        public string LocationConstraint { get; set; }


        /// <summary>
        /// Maximum number of parts in a multipart upload (default 10000)
        /// </summary>
        [UintFlag("max-upload-parts", 10000, 2)]
        public uint? MaxUploadParts { get; set; }


        /// <summary>
        /// How often internal memory buffer pools will be flushed (default 1m0s)
        /// </summary>
        [TimeSpanFlag("memory-pool-flush-time", "1m")]
        public TimeSpan? MemoryPoolFlushTime { get; set; }


        /// <summary>
        /// Whether to use mmap buffers in internal memory pool
        /// </summary>
        [BoolFlag("memory-pool-use-mmap")]
        public bool MemoryPoolUseMmap { get; set; }


        /// <summary>
        /// If set, don&#39;t attempt to check the bucket exists or create it
        /// </summary>
        [BoolFlag("no-check-bucket")]
        public bool NoCheckBucket { get; set; }


        /// <summary>
        /// If set, don&#39;t HEAD uploaded objects to check integrity
        /// </summary>
        [BoolFlag("no-head")]
        public bool NoHead { get; set; }


        /// <summary>
        /// If set, do not do HEAD before GET when getting objects
        /// </summary>
        [BoolFlag("no-head-object")]
        public bool NoHeadObject { get; set; }


        /// <summary>
        /// Suppress setting and reading of system metadata
        /// </summary>
        [BoolFlag("no-system-metadata")]
        public bool NoSystemMetadata { get; set; }


        /// <summary>
        /// Profile to use in the shared credentials file
        /// </summary>
        [StringFlag("profile")]
        public string Profile { get; set; }


        /// <summary>
        /// Choose your S3 provider
        /// </summary>
        [SingleEnumFlag("provider", (int)Providers.AWS)]
        public Providers? Provider { get; set; }


        /// <summary>
        /// Region to connect to
        /// </summary>
        [StringFlag("region")]
        public string Region { get; set; }


        /// <summary>
        /// Enables requester pays option when interacting with S3 bucket
        /// </summary>
        [BoolFlag("requester-pays")]
        public bool RequesterPays { get; set; }


        /// <summary>
        /// AWS Secret Access Key (password)
        /// </summary>
        [StringFlag("secret-access-key")]
        public string SecretAccessKey { get; set; }


        /// <summary>
        /// The server-side encryption algorithm used when storing this object in S3
        /// </summary>
        [StringFlag("server-side-encryption")]
        public string ServerSideEncryption { get; set; }


        /// <summary>
        /// An AWS session token
        /// </summary>
        [StringFlag("session-token")]
        public string SessionToken { get; set; }


        /// <summary>
        /// Path to the shared credentials file
        /// </summary>
        [StringFlag("shared-credentials-file")]
        public string SharedCredentialsFile { get; set; }


        /// <summary>
        /// If using SSE-C, the server-side encryption algorithm used when storing this object in S3
        /// </summary>
        [StringFlag("sse-customer-algorithm")]
        public string SseCustomerAlgorithm { get; set; }


        /// <summary>
        /// To use SSE-C you may provide the secret encryption key used to encrypt/decrypt your data
        /// </summary>
        [StringFlag("sse-customer-key")]
        public string SseCustomerKey { get; set; }


        /// <summary>
        /// If using SSE-C you must provide the secret encryption key encoded in base64 format to encrypt/decrypt your data
        /// </summary>
        [StringFlag("sse-customer-key-base64")]
        public string SseCustomerKeyBase64 { get; set; }


        /// <summary>
        /// If using SSE-C you may provide the secret encryption key MD5 checksum (optional)
        /// </summary>
        [StringFlag("sse-customer-key-md5")]
        public string SseCustomerKeyMd5 { get; set; }


        /// <summary>
        /// If using KMS ID you must provide the ARN of Key
        /// </summary>
        [StringFlag("sse-kms-key-id")]
        public string SseKmsKeyId { get; set; }


        /// <summary>
        /// The storage class to use when storing new objects in S3
        /// </summary>
        [StringFlag("storage-class")]
        public string StorageClass { get; set; }


        /// <summary>
        /// Concurrency for multipart uploads (default 4)
        /// </summary>
        [UintFlag("upload-concurrency", 4, 1)]
        public uint? UploadConcurrency { get; set; }


        /// <summary>
        /// Cutoff for switching to chunked upload (default 200Mi)
        /// </summary>
        [SizeSuffixFlag("upload-cutoff", "200M")]
        public SizeSuffix UploadCutoff { get; set; }


        /// <summary>
        /// If true use the AWS S3 accelerated endpoint
        /// </summary>
        [BoolFlag("use-accelerate-endpoint")]
        public bool UseAccelerateEndpoint { get; set; }


        /// <summary>
        /// Whether to use ETag in multipart uploads for verification (default unset)
        /// </summary>
        [TristateFlag("use-multipart-etag")]
        public bool? UseMultipartEtag { get; set; }


        /// <summary>
        /// Whether to use a presigned request or PutObject for single part uploads
        /// </summary>
        [BoolFlag("use-presigned-request")]
        public bool UsePresignedRequest { get; set; }


        /// <summary>
        /// If true use v2 authentication
        /// </summary>
        [BoolFlag("v2-auth")]
        public bool V2Auth { get; set; }


        /// <summary>
        /// Show file versions as they were at the specified time (default off)
        /// </summary>
        [DateTimeFlag("version-at")]
        public DateTime? VersionAt { get; set; }


        /// <summary>
        /// Include old versions in directory listings
        /// </summary>
        [BoolFlag("versions")]
        public bool Versions { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
