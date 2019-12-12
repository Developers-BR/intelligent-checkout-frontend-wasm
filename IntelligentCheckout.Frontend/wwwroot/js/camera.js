window.initPicture = function () {
	var canvas = document.createElement('canvas');
	canvas.width = 800;
	canvas.height = 600;
    var context = canvas.getContext('2d');
    var video = document.getElementById('video');

    var mediaConfig = { video: true };

    var errBack = function (e) {
        console.log('An error has ocurred: ', e);
    };

	window.startPicture = function () {
		if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
			navigator.mediaDevices.getUserMedia(mediaConfig).then(function (stream) {
				video.srcObject = stream;
				video.play();
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
		context.drawImage(video, 0, 0, 800, 600);
	};

	window.exportPicture = function () {
		return canvas.toDataURL("image/jpg");
	};

	window.stopPicture = function () {
		video.pause();
		if (video.srcObject && video.srcObject.getTracks()) {
			video.srcObject.getTracks().forEach(function (track) { track.stop(); });
		}
	};
}