"use strict";

var util = require('util');
var SensorService = require("../services/sensors-service");
var BaseController = require("./base-controller");
var underscore = require("underscore");

var sensorService = new SensorService();

var SensorsController = function () {
};

util.inherits(SensorsController, BaseController);

SensorsController.prototype.getAllSensors = function (req, res) {
  
  sensorService.getAllSensors(function (err, result) {
    if (err) {
      res.send({ error: "error", message: err });
    } else {
      res.send({ status: "Success", result: result });
    }
  });
};

SensorsController.prototype.getLocationUpdatesBySensor = function (req, res) {
  var id = req.params.id;

  sensorService.getLocationUpdatesBySensor(id, function (err, result) {
    if (err) {
      res.send({ error: "error", message: err });
    } else {
      res.send({ status: "Success", result: result });
    }
  });
};

module.exports = SensorsController;