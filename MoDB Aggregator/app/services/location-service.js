"use strict";

var util = require('util');
var BaseService = require("./base-service");
var ObjectId = require("mongodb").ObjectID;
var _ = require("underscore");

var LocationService = function () {

};

util.inherits(LocationService, BaseService);

LocationService.prototype.updateLocation = function (locationInfo, callback) {
  var query = 'INSERT INTO "LocationUpdate" ("Id", "Name", "DeviceId" ,"Date", "SensorId", "Rssi")' + 
  'VALUES($1, $2, $3, $4, $5, $6);';
  
  var data = [
    
  ];
  
  _.each(locationInfo, function (location) {
    data.push([
      new ObjectId(), location.DeviceName, location.DeviceId, new Date(), location.SensorId, location.Rssi
    ]);
  });
  
  this.createDocuments(query, data, callback);
};

LocationService.prototype.getRecentEntries = function (index, limit, callback) {
  var query = 'SELECT * FROM "LocationUpdate" ' + 
    ' Where itemindex >=  ' + index +
  ' ORDER BY itemindex ASC LIMIT ' + limit + ';';
  this.executeSelectQuery(query, callback);
};

LocationService.prototype.getFilteredLocationUpdatesBySensor = function (id, from, to, callback) {
  var query = 'SELECT * FROM "LocationUpdate" ' + 
    ' Where "SensorId" =  \'' + id + '\'' + 
  ' AND "Date" BETWEEN \'' + from + '\' AND \'' + to +"\';";
  this.executeSelectQuery(query, callback);
};

LocationService.prototype.getFilteredLocationUpdatesByDevice = function (id, from, to, callback) {
  var query = 'SELECT * FROM "LocationUpdate" ' + 
    ' Where "DeviceId" =  \'' + id + '\'' + 
  ' AND "Date" BETWEEN \'' + from + '\' AND \'' + to + "\';";
  this.executeSelectQuery(query, callback);
};


LocationService.prototype.deleteLocationDocuments = function (ids, callback) {
  this.deleteDocuments("location", ids, callback)
};

module.exports = LocationService;