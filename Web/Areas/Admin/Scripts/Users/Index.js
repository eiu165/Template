(function() {
  var Person, PersonListViewModel, Vehicle;

  Person = function(data) {
    var name;
    name = ko.observable(data.name);
    return {
      name: name
    };
  };

  Vehicle = function(data) {
    var make;
    make = ko.observable(data.make);
    return {
      make: make
    };
  };

  PersonListViewModel = function() {
    var addPerson, load, map, people, removePerson, save, vehicle;
    people = ko.observableArray([]);
    vehicle = ko.observableArray([]);
    addPerson = function() {
      return people.push({
        name: "New at " + new Date()
      });
    };
    removePerson = function() {
      return people.remove(this);
    };
    load = function() {
      var allData;
      console.log('load');
      allData = '{"people" : [{"name":"a"},{"name":"b"},{"name":"c"}],  "vehicle" : [{"make":"x"},{"make":"z"}]}';
      return map(allData);
    };
    map = function(data) {
      var mappedItems, mappedV;
      mappedItems = $.map($.parseJSON(data).people, function(item) {
        return Person(item);
      });
      people(mappedItems);
      mappedV = $.map($.parseJSON(data).vehicle, function(item) {
        return Vehicle(item);
      });
      return vehicle(mappedV);
    };
    save = function() {
      return console.log('save');
    };
    return {
      people: people,
      vehicle: vehicle,
      load: load,
      save: save,
      addPerson: addPerson,
      removePerson: removePerson
    };
  };

  $(function() {
    var a;
    a = new PersonListViewModel();
    a.load();
    ko.applyBindings(a);
    return this;
  });

}).call(this);
