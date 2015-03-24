"use strict";

var util = require('util');
var BaseService = require("./base-service");
var _ = require("underscore");

var LocationService = function () {

};

util.inherits(LocationService, BaseService);

LocationService.prototype.updateLocation = function (locationInfo, callback) {
  var doc = {
    time: new Date(),
    data: locationInfo
  };
  this.saveDocument("location", doc, "testuser", callback);
};

LocationService.prototype.getRecentEntries = function (callback) {
  this.getRecentFromCollection("location", callback);
};

LocationService.prototype.deleteDocuments = function (id, callback) {
  var doc = {
    _id: id
  }
  this.deleteDocument("location", doc, callback)
};

module.exports = LocationService;