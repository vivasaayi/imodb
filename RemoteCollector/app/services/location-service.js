"use strict";

var util = require('util');
var BaseService = require("./base-service");
var _ = require("underscore");

var LocationService = function () {

};

util.inherits(LocationService, BaseService);

LocationService.prototype.updateLocation = function (locationInfo, callback) {
  this.saveDocument("location", locationInfo, "testuser", callback);
};

LocationService.prototype.getRecentEntries = function (callback) {
  this.getRecentFromCollection("location", callback);
};

module.exports = LocationService;