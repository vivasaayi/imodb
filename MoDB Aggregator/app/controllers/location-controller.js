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
      res.send({ error: "error", message: err });
    } else {
      res.send({ status: "Saved" });
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

LocationController.prototype.deleteDocuments = function (req, res) {
  var idsAsString = req.params.ids;
  
  if (idsAsString === null || idsAsString === undefined || idsAsString === "") {
    return res.send({ error: "error", message: "Please specify the document ids." });
  }
  
  var ids = idsAsString.split(",");
  
  locationService.deleteLocationDocuments(ids, function (err) {
    if (err) {
      res.send({ error: "error deleting documents", message: err });
    } else {
      res.send({ status: "Success", result: "Documents deleted." });
    }
  });
};


module.exports = LocationController;