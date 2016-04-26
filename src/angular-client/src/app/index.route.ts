/** @ngInject */
export function routerConfig($stateProvider: angular.ui.IStateProvider, $urlRouterProvider: angular.ui.IUrlRouterProvider) {
  $stateProvider
  .state('home', {
    url: '/',
    templateUrl: 'app/main/main.html',
    controller: 'MainController',
    controllerAs: 'main'
  });

  $stateProvider.state('devices',{
    url:'/devices',
    templateUrl:'app/devices/list.html',
    controller:'DeviceController',
    controllerAs:'devices'
  })

  $urlRouterProvider.otherwise('/devices');
}
