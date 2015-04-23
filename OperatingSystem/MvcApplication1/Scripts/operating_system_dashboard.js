(function () {
    var page =
        {
            init: function () {
                console.log('page init');
                page.attachElements();
                page.attachEvents();
            },

            attachElements: function () {
                page.$incrementClock = $('#incrementClock');
                page.$resetProgram = $('#reset');
                page.$startupSubmit = $('#startProgram');
                page.$queue = $('#processQueue');
                page.$memory = $('#memory');
                page.$clock = $('#clock');
                page.$addPCB = $('#addPCB');

                //  process form values
                page.$processId = $('#processId');
                page.$memorySize = $('#memorySize');
                page.duration = $('#duration');
                page.$delay = $('#delay');

                //  initialize form values
                page.$totalMemorySize = $('#totalMemorySize');
                page.$allocationStrategy = $('#allocationStrategy');
            },

            attachEvents: function () {
                page.$incrementClock.click(page.incrementClock);
                page.$startupSubmit.click(page.initializeProgram);
                page.$resetProgram.click(page.initializeProgram);
                page.$addPCB.click(page.addPCB);
            },

            updateMemory: function () {
                alert('updating memory');

            },

            updateQueue: function () {
                alert('updating queue');


            },

            incrementClock: function () {
                alert('incrementing clock');

                page.updateMemory();
            },

            resetProgram: function () {
                alert('reseting program');


            },

            addPCB: function () {
                alert('adding PCB');

                page.updateQueue();
            },

            initializeProgram: function () {
                alert('initializing program');


            },

            handleError: function (err) {
                alert(err.Message);
            }
        };

    $(window).load(page.init);
})();