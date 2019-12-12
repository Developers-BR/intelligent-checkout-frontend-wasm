window.initPicture = function () {
    var mediaConfig = { video: true };

    var errBack = function (e) {
        console.log('An error has ocurred: ', e);
    };

	window.startPicture = function () {
		var video = document.getElementById('video');

		if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
			navigator.mediaDevices.getUserMedia(mediaConfig).then(function (stream) {
				video.srcObject = stream;
				video.play();
				console.log(video.srcObject);
			});
		}

		else if (navigator.getUserMedia) {
			navigator.getUserMedia(mediaConfig, function (stream) {
				video.src = stream;
				video.play();
			}, errBack);
		} else if (navigator.webkitGetUserMedia) {
			navigator.webkitGetUserMedia(mediaConfig, function (stream) {
				video.src = window.webkitURL.createObjectURL(stream);
				video.play();
			}, errBack);
		} else if (navigator.mozGetUserMedia) {
			navigator.mozGetUserMedia(mediaConfig, function (stream) {
				video.src = window.URL.createObjectURL(stream);
				video.play();
			}, errBack);
		}
	};

	window.snapPicture = function () {
		var canvas = document.createElement('canvas');
		canvas.width = 1024;
		canvas.height = 768;
		var context = canvas.getContext('2d');
		context.drawImage(video, 0, 0, 1024, 768);
	};

	window.exportPicture = function () {
		var canvas = document.createElement('canvas');
		canvas.width = 800;
		canvas.height = 600;
		var context = canvas.getContext('2d');
		context.drawImage(video, 0, 0, 1024, 768);
		return canvas.toDataURL("image/jpeg", 0.5);
	};

	window.stopPicture = function () {
		var video = document.getElementById('video');

		if (video.srcObject && video.srcObject.getTracks()) {
			video.srcObject.getTracks().forEach(function (track) { track.stop(); });
		}
		video.pause();
		video.load();
	};
}