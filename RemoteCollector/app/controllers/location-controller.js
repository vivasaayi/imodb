"use strict";

var util = require('util');
var LocationService = require("../services/location-service");
var BaseController = require("./base-controller");
var underscore = require("underscore");

var locationService = new LocationService();

var LocationController = function () {
};

util.inherits(LocationController, BaseController);

LocationController.prototype.updateLocation = function (req, res) {
  var details = req.body;
  
  var locationInfo = req.body;
  
  locationService.updateLocation(locationInfo, function (err, result) {
    if (err) {
      res.send({error: "error", message: err});
    } else {
      res.send({status: "Saved"});
    }
  });
};

LocationController.prototype.getRecentEntries = function (req, res) {  
  locationService.getRecentEntries(function (err, result) {
    if (err) {
      res.send({ error: "error", message: err });
    } else {
      res.send({ status: "Success", result: result });
    }
  });
};

module.exports = LocationController;