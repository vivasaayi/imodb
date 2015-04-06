"use strict";

var util = require('util');
var BaseService = require("./base-service");
var ObjectId = require("mongodb").ObjectID;
var _ = require("underscore");

var DevicesService = function () {

};

util.inherits(DevicesService, BaseService);

DevicesService.prototype.getAllDevices = function (callback) {
  var query = 'SELECT DISTINCT "DeviceId", "Name" FROM "LocationUpdate";';
  this.executeSelectQuery(query, callback);
};

DevicesService.prototype.getLocationUpdatesBySensor = function (id, callback) {
  var query = 'SELECT * FROM "LocationUpdate" ' + 
    ' Where "SensorId" =  \'' + id + '\'' + 
  ' ORDER BY itemindex ASC LIMIT 500;';
  this.executeSelectQuery(query, callback);
};

DevicesService.prototype.getUpdatesWhichTagsDevice = function (id, callback) {
  var query = 'SELECT * FROM "LocationUpdate" ' + 
    ' Where "DeviceId" =  \'' + id + '\'' + 
  ' ORDER BY itemindex ASC LIMIT 500;';
  this.executeSelectQuery(query, callback);
};

module.exports = DevicesService;