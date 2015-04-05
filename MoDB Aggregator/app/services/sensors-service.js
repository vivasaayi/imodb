"use strict";

var util = require('util');
var BaseService = require("./base-service");
var ObjectId = require("mongodb").ObjectID;
var _ = require("underscore");

var SensorsService = function () {

};

util.inherits(SensorsService, BaseService);

SensorsService.prototype.getAllSensors = function (callback) {
  var query = 'SELECT DISTINCT "SensorId" FROM "LocationUpdate";';
  this.executeSelectQuery(query, callback);
};

SensorsService.prototype.getLocationUpdatesBySensor = function (id, callback) {
  var query = 'SELECT * FROM "LocationUpdate" ' + 
    ' Where "SensorId" =  \'' + id + '\'' + 
  ' ORDER BY itemindex ASC LIMIT 500;';
  this.executeSelectQuery(query, callback);
};

module.exports = SensorsService;