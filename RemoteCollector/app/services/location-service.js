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

module.exports = LocationService;