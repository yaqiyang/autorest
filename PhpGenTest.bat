
set autorest=src\core\AutoRest\bin\Debug\net451\win7-x64\AutoRest.exe
set master=https://raw.githubusercontent.com/azure/azure-rest-api-specs/master
set outfolder=D:\Repos\php-sdk-dev\src\Arm

rd /s /q %outfolder%

%autorest% -i %master%/arm-authorization/2015-07-01/swagger/authorization.json -n "MicrosoftAzure\Arm\Authorization" -pn "Authorization" -g Azure.Php -o %outfolder%
%autorest% -i %master%/arm-batch/2015-12-01/swagger/BatchManagement.json -n "MicrosoftAzure\Arm\Batch" -pn "Batch" -g Azure.Php -o %outfolder%
%autorest% -i %master%/arm-cdn/2016-04-02/swagger/cdn.json -n "MicrosoftAzure\Arm\Cdn" -pn "Cdn" -g Azure.Php -o %outfolder%
%autorest% -i %master%/arm-cognitiveservices/2016-02-01-preview/swagger/cognitiveservices.json -n "MicrosoftAzure\Arm\CognitiveServices" -pn "CognitiveServices" -g Azure.Php -o %outfolder%
%autorest% -i %master%/arm-commerce/2015-06-01-preview/swagger/commerce.json -n "MicrosoftAzure\Arm\Commerce" -pn "Commerce" -g Azure.Php -o %outfolder%

%autorest% -i %master%/arm-compute/2016-03-30/swagger/compute.json -n "MicrosoftAzure\Arm\Compute" -pn "Compute" -g Azure.Php -o %outfolder%
%autorest% -i %master%/arm-datalake-analytics/catalog/2015-10-01-preview/swagger/catalog.json -n "MicrosoftAzure\Arm\DataLakeAnalyticsCatalog" -pn "DataLakeAnalyticsCatalog" -g Azure.Php -o %outfolder%
%autorest% -i %master%/arm-datalake-analytics/job/2016-03-20-preview/swagger/job.json -n "MicrosoftAzure\Arm\DataLakeAnalyticsJob" -pn "DataLakeAnalyticsJob" -g Azure.Php -o %outfolder%
%autorest% -i %master%/arm-datalake-analytics/account/2015-10-01-preview/swagger/account.json -n "MicrosoftAzure\Arm\DataLakeAnalyticsAccount" -pn "DataLakeAnalyticsAccount" -g Azure.Php -o %outfolder%
%autorest% -i %master%/arm-datalake-store/filesystem/2015-10-01-preview/swagger/filesystem.json -n "MicrosoftAzure\Arm\DataLakeStoreFileSystem" -pn "DataLakeStoreFileSystem" -g Azure.Php -o %outfolder%

%autorest% -i %master%/arm-datalake-store/account/2015-10-01-preview/swagger/account.json -n "MicrosoftAzure\Arm\DataLakeStoreAccount" -pn "DataLakeStoreAccount" -g Azure.Php -o %outfolder%
%autorest% -i %master%/arm-devtestlabs/2016-05-15/swagger/DTL.json -n "MicrosoftAzure\Arm\DevTestLabs" -pn "DevTestLabs" -g Azure.Php -o %outfolder%
%autorest% -i %master%/arm-dns/2016-04-01/swagger/dns.json -n "MicrosoftAzure\Arm\Dns" -pn "Dns" -g Azure.Php -o %outfolder%
%autorest% -i %master%/arm-resources/features/2015-12-01/swagger/features.json -n "MicrosoftAzure\Arm\Features" -pn "Features" -g Azure.Php -o %outfolder%
%autorest% -i %master%/arm-graphrbac/1.6/swagger/graphrbac.json -n "MicrosoftAzure\Arm\Graph" -pn "Graph" -g Azure.Php -o %outfolder%

REM %autorest% -i %master%/arm-intune/2015-01-14-preview/swagger/intune.json -n "MicrosoftAzure\Arm\Intune" -pn "Intune" -g Azure.Php -o %outfolder%
%autorest% -i %master%/arm-resources/locks/2015-01-01/swagger/locks.json -n "MicrosoftAzure\Arm\Locks" -pn "Locks" -g Azure.Php -o %outfolder%
%autorest% -i %master%/arm-logic/2015-08-01-preview/swagger/logic.json -n "MicrosoftAzure\Arm\Logic" -pn "Logic" -g Azure.Php -o %outfolder%
%autorest% -i %master%/arm-machinelearning/2016-05-01-preview/swagger/webservices.json -n "MicrosoftAzure\Arm\MachineLearning" -pn "MachineLearning" -g Azure.Php -o %outfolder%
%autorest% -i %master%/arm-mediaservices/2015-10-01/swagger/media.json -n "MicrosoftAzure\Arm\MediaServices" -pn "MediaServices" -g Azure.Php -o %outfolder%

%autorest% -i %master%/arm-mobileengagement/2014-12-01/swagger/mobile-engagement.json -n "MicrosoftAzure\Arm\MobileEngagement" -pn "MobileEngagement" -g Azure.Php -o %outfolder%
%autorest% -i %master%/arm-network/2016-06-01/swagger/network.json -n "MicrosoftAzure\Arm\Network" -pn "Network" -g Azure.Php -o %outfolder%
%autorest% -i %master%/arm-notificationhubs/2014-09-01/swagger/notificationhubs.json -n "MicrosoftAzure\Arm\NotificationHubs" -pn "NotificationHubs" -g Azure.Php -o %outfolder%
%autorest% -i %master%/arm-resources/policy/2016-04-01/swagger/policy.json -n "MicrosoftAzure\Arm\Policy" -pn "Policy" -g Azure.Php -o %outfolder%
%autorest% -i %master%/arm-powerbiembedded/2016-01-29/swagger/powerbiembedded.json -n "MicrosoftAzure\Arm\PowerBiEmbedded" -pn "PowerBiEmbedded" -g Azure.Php -o %outfolder%

%autorest% -i %master%/arm-redis/2016-04-01/swagger/redis.json -n "MicrosoftAzure\Arm\Redis" -pn "Redis" -g Azure.Php -o %outfolder%
%autorest% -i %master%/arm-resources/resources/2016-02-01/swagger/resources.json -n "MicrosoftAzure\Arm\Resources" -pn "Resources" -g Azure.Php -o %outfolder%
%autorest% -i %master%/arm-scheduler/2016-03-01/swagger/scheduler.json -n "MicrosoftAzure\Arm\Scheduler" -pn "Scheduler" -g Azure.Php -o %outfolder%
%autorest% -i %master%/arm-search/2015-02-28/swagger/search.json -n "MicrosoftAzure\Arm\Search" -pn "Search" -g Azure.Php -o %outfolder%
%autorest% -i %master%/arm-servermanagement/2015-07-01-preview/servermanagement.json -n "MicrosoftAzure\Arm\ServerManagement" -pn "ServerManagement" -g Azure.Php -o %outfolder%

%autorest% -i %master%/arm-servicebus/2014-09-01/swagger/servicebus.json -n "MicrosoftAzure\Arm\ServiceBus" -pn "ServiceBus" -g Azure.Php -o %outfolder%
%autorest% -i %master%/arm-sql/2015-05-01/swagger/sql.json -n "MicrosoftAzure\Arm\Sql" -pn "Sql" -g Azure.Php -o %outfolder%
%autorest% -i %master%/arm-storage/2016-01-01/swagger/storage.json -n "MicrosoftAzure\Arm\Storage" -pn "Storage" -g Azure.Php -o %outfolder%
%autorest% -i %master%/arm-resources/subscriptions/2015-11-01/swagger/subscriptions.json -n "MicrosoftAzure\Arm\Subscriptions" -pn "Subscriptions" -g Azure.Php -o %outfolder%
%autorest% -i %master%/arm-trafficmanager/2015-11-01/trafficmanager.json -n "MicrosoftAzure\Arm\TrafficManager" -pn "TrafficManager" -g Azure.Php -o %outfolder%

%autorest% -i %master%/arm-web/2015-08-01/swagger/service.json -n "MicrosoftAzure\Arm\Web" -pn "Web" -g Azure.Php -o %outfolder%


REM src\core\AutoRest\bin\Debug\net451\win7-x64\AutoRest.exe -i "https://raw.githubusercontent.com/azure/azure-rest-api-specs/master/arm-storage/2016-01-01/swagger/storage.json" -n "MicrosoftAzure\StorageResourceProvider" -pn "StorageResourceProvider" -g Azure.Php -o "D:\Repos\php-sdk-dev\src"
