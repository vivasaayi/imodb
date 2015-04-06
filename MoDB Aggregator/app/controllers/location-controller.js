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

LocationController.prototype.getFilteredLocationUpdatesBySensor = function (req, res) {
  var from = req.query.from;
  var to = req.query.to;
  var id = req.query.id;
  
  
  locationService.getFilteredLocationUpdatesBySensor(id, from, to, function (err, result) {
    if (err) {
      res.send({ error: "error", message: err });
    } else {
      res.send({ status: "Success", result: result });
    }
  });
};

LocationController.prototype.getFilteredLocationUpdatesByDevice = function (req, res) {
  var from = req.query.from;
  var to = req.query.to;
  var id = req.query.id;
  
  
  locationService.getFilteredLocationUpdatesByDevice(id, from, to, function (err, result) {
    if (err) {
      res.send({ error: "error", message: err });
    } else {
      res.send({ status: "Success", result: result });
    }
  });
};

LocationController.prototype.getRecentEntries = function (req, res) {
  var limit = req.query.limit || 20;
  var index = req.query.index || 0;
  
  locationService.getRecentEntries(index, limit, function (err, result) {
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