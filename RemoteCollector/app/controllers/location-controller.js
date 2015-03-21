"use strict";

var util = require('util');
var LocationService = require("../services/location-service");
var BaseController = require("./base-controller");

var locationService = new LocationService();

var LocationController = function () {
};

util.inherits(LocationController, BaseController);

LocationController.prototype.updateLocation = function (req, res) {
  var details = req.body;

  locationService.updateLocation(details, function (err, result) {
    if (err) {
      res.send({error: "error", message: result.message});
    } else {
      res.send({status: "Saved"});
    }
  });
};

module.exports = LocationController;