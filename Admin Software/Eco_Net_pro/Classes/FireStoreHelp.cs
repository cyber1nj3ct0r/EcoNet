using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco_Net_pro.Classes
{
    internal static class FireStoreHelp
    {
        static string fireconfig = @"
            {
              ""type"": ""service_account"",
              ""project_id"": ""econet-store"",
              ""private_key_id"": ""49a2d3a88ce6b1e625cf53ce6491d87f89b9245a"",
              ""private_key"": ""-----BEGIN PRIVATE KEY-----\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQClv2o4+3xbUhlq\nklvt3gXBletYqidzp8lwIp6o9PeYnaKnqmvAVp7xuOXLSoN0aibplvpAbmi8r7Yv\ncNGNLt2img6SDT3vLETwXDUG8MsQHY1O0fXikc90nrJbpFv9pAbf7GQ4soRlcxOf\n1XrFDuSNrM9CWredbYL11pnTwmcEQXliUZz/AOuUbPp6n/wQ46dVhEC3ADXnL8hd\nsZ4unQlS2+SHL4cfSNHt9QXyM6OZ+sAHbdSv621FnZRiSshrVIwFrsM3evhr0+ZI\npleWIkT/T52lNg3AHlUkbt4PN5E8O9422w+8CuVgoQpKb6lYlpMjOa1g5+EisthD\nKwX4mY53AgMBAAECggEAINKBBHu4qpTdd584GSioVyeLDWnUmjCV0WDprmekSFKf\nDTjQUaxVmWSWDOXalkkXH5bIQ84Za5QYLdjXhm/LcBG15PI+W4iWtkpsLc2tSKmx\ne/RUDuP1AxESHNe1Z8r9mYZEan3fff+F2Vb7Et7aH7wi5u70AXbYQjqXB7otkEfc\n3ZV7yEsKDxF/8B/y030t1frOpy4NYLMVmqRfiT+h+Rm/T9ephoXVDS43lv6QBv2T\nxIjCOdZ2L4IOcUGGAsshfCmV7isMxwLbLGtrCcaXSkMp5+73spIxXUZTz/4j9k8S\nMUhWpBpzmNWitWdsbXFtRVSwK1fOjCxllRXPHU49sQKBgQDmLD8ZxUvXemkW51J7\nKNah6KUmFS2TGpncarnSU5/VYEWPw3eXAKDqU325nY7t93z/OKpF0f7RVwVRB+4I\nHlIwcY+25rpHElVyVlSAO8lpIZoNqrjMlUIcHga7Wb/ZPCpOKBTMOkks3bqjbVOT\nIILqA1wuwp/zmCXsyrKI+cSQLQKBgQC4WIvCWh7DBuPVqA5xBMV4PtGtlrkZkosl\nPOZ5QG9Z4qeGFjtIuVFlbu0VtL5ze8wWsO2jQGGfFrZJXPd+c0EoqSrNg4HeFhQq\n0WfTisLiFSEknBCc3I0p2MSCX0RuzyDmQIMedAuolkkoWisAs3Gy2qD8bZkzLFyE\njVo5oUQbswKBgDTnII20yiy5huPrwQprpYFLLoIlRfdUmt6NbS5JaCgr23EilR8Q\n1utkyzXZX9uUEZe7l286x92nqaIpN22IQo293DFGsLPbI+aGrx9WHoHaZkUT4yuq\ndqptwFBZXX35lSOnlLgoAV+diuM7IoVjaJOOuCZLN2ZOpxDYudY/ygz1AoGAYPY5\n9K0ANyadmdi+V9Xho+Cu2vZHP9sjkx+YPjiVGRstcEqrPhIzbP3OeDdMYWPBMkI3\njEGl107T7HyYtQscP63TFKvSGCVW0Dq6uLrozI++kgoAdvFO0q7wlX5UeVA7BsDx\n9oelRjReIHpk2gaIjEGQoZVoGlGADDxpM5zOPR8CgYEAnb5v2OKur0rmaQkhHhTG\nfKqDO79FjawQm2WEfGHPAxN79AJ5ctCSXRNpFKwyDe6cRbyrSkf9NqDf+ON2O3LA\nLI2wJcFqGxmODH1JevzFcJW0MPSyB+HA331w/9NGiVOLdLv7eBCaoTONBDBR6LUK\nJUIPtMAhvIj+110sIY/JBhM=\n-----END PRIVATE KEY-----\n"",
              ""client_email"": ""firebase-adminsdk-wzx1p@econet-store.iam.gserviceaccount.com"",
              ""client_id"": ""103052901170381687125"",
              ""auth_uri"": ""https://accounts.google.com/o/oauth2/auth"",
              ""token_uri"": ""https://oauth2.googleapis.com/token"",
              ""auth_provider_x509_cert_url"": ""https://www.googleapis.com/oauth2/v1/certs"",
              ""client_x509_cert_url"": ""https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-wzx1p%40econet-store.iam.gserviceaccount.com"",
              ""universe_domain"": ""googleapis.com""
            } ";

        static string filepath = "";
        public static FirestoreDb Database {  get; private set; }

        public static void setEnvironmentVariable()
        {
            filepath = Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName())) + ".json";
            File.WriteAllText(filepath, fireconfig);
            File.SetAttributes(filepath, FileAttributes.Hidden);
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS",filepath);
            Database = FirestoreDb.Create("econet-store");
            File.Delete(filepath);
        }
    }
}
