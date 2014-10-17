var Tutorial = {
	run: function () {
		// Init
		var canvas = document.getElementById("renderCanvas");
		var engine = new BABYLON.Engine(canvas, true);
		var scene = new BABYLON.Scene(engine);
		var camera = new BABYLON.ArcRotateCamera("ArcRotateCamera", 1, 0.8, 10, new BABYLON.Vector3(0, 3, 0), scene);
		var vrCamera = new BABYLON.VRDeviceOrientationCamera("VRDeviceCamera", new BABYLON.Vector3(0, 10, 0), scene);
		scene.activeCamera = camera;
		scene.activeCamera.attachControl(canvas);
		
		var light = new BABYLON.DirectionalLight("DirLight", new BABYLON.Vector3(1, -1, 0), scene);
		light.diffuse = new BABYLON.Color3(1, 1, 1);
		light.specular = new BABYLON.Color3(0.3, 0.3, 0.3);
		light.intensity = 1.5;

		// Génération de la grile
		var grid = new HexGridBuilder(15, 15, 1);
		grid.generate(scene);
		
		// Activation du mode VR
		var vrEnabled = false;
		var vr = document.getElementById("vr");
		
		var onToggleVRMode = function (event) {
			scene.activeCamera.detachControl(canvas);
			
			if (vrEnabled || event.forceNormal) {
				scene.activeCamera = camera;
				scene.activeCamera.attachControl(canvas);
				BABYLON.Tools.ExitFullscreen();
			}
			else {
				scene.activeCamera = vrCamera;
				scene.activeCamera.attachControl(canvas);
				BABYLON.Tools.RequestFullscreen(canvas);
			}
		};
		
		vr.addEventListener("click", onToggleVRMode, false);
		
		// Reset de la caméra à l'appuis sur escape.
		vr.addEventListener("keydown", function (event) {
			if (event.keyCode === 27) {
				onToggleVRMode({ forceNormal: true });
			}
		}, false);
		
		// Changement de couleur au clic de souris/touch
		var highlightedTile = null;
		var highlightedMaterial = new BABYLON.StandardMaterial("hlMat", scene);
		highlightedMaterial.diffuseColor = new BABYLON.Color3(1.0, 0.0, 0.0);
		highlightedMaterial.alpha = 0.8;
		
		var onClickHandler = function (event) {
			var pick = scene.pick(event.clientX, event.clientY);
			
			if (pick.pickedMesh && pick.pickedMesh !== highlightedTile) {
				var pickedMesh = pick.pickedMesh;
				
				if (highlightedTile) {
					highlightedTile.material = highlightedTile.oldMaterial;
					highlightedTile.oldMaterial = null;
				}
	
				pickedMesh.oldMaterial = pickedMesh.material;
				pickedMesh.material = highlightedMaterial;
				highlightedTile = pickedMesh;
				
				console.log(highlightedTile.hexPosition);
			}
			else {
				if (highlightedTile) {
					highlightedTile.material = highlightedTile.oldMaterial;
					highlightedTile.oldMaterial = null;
					highlightedTile = null;
				}
			}
		};
		
		document.body.addEventListener("pointerdown", onClickHandler, false);
		//document.body.addEventListener("click", onClickHandler, false);
		
		engine.runRenderLoop(function() {
			scene.render();
		});
	}
};