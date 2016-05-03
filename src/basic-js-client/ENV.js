const ENV = {
    authorizationUrl    : 'https://dev-oauth1.azurewebsites.net/oauth/ls/connect/authorize',
    redirectUrl         : 'http://localhost:44305/index.html',
    apigw   : {
        region : 'us-west-2'
    },
    cognito : {
        region          : 'ap-northeast-1',    
        IdentityPoolId  : 'ap-northeast-1:694719c8-eb8d-4df0-b4e6-fe0a893ed278',
        provider : 'dev-oauth1.azurewebsites.net/oauth/ls'
    },
    dynamo : {
        region      : 'ap-northeast-1',
        tableName   : 'Messages'
    }
};
