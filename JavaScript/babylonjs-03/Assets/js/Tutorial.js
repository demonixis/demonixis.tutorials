var Tutorial = {
	run: function () {
		var canvas = document.getElementById("renderCanvas");
		var engine = new BABYLON.Engine(canvas, true);
		var scene = new BABYLON.Scene(engine);
		var camera = new BABYLON.ArcRotateCamera("ArcRotateCamera", 1, 0.8, 10, new BABYLON.Vector3(0, 3, 0), scene);
		//var camera = new BABYLON.VRDeviceOrientationCamera("VRDeviceCamera", new BABYLON.Vector3(0, 10, 0), scene);
		scene.activeCamera.attachControl(canvas);
		
		var light = new BABYLON.DirectionalLight("DirLight", new BABYLON.Vector3(1, -1, 0), scene);
		light.diffuse = new BABYLON.Color3(1, 1, 1);
		light.specular = new BABYLON.Color3(0.3, 0.3, 0.3);
		light.intensity = 1.5;

		var grid = new HexGridBuilder(15, 15, 1);
		grid.generate(scene);
		
		var d = document.getElementById("d");
		
		var highlightedMaterial = new BABYLON.StandardMaterial("hlMat", scene);
		highlightedMaterial.diffuseColor = new BABYLON.Color3(1.0, 0.0, 0.0);
		highlightedMaterial.alpha = 0.8;
		
		var highlightedTile = null;
		
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
				
				var debug = "Hex grid coordinates<br /> X: " + highlightedTile.hexPosition.x;
				debug += " Y: " + highlightedTile.hexPosition.z;
				d.innerHTML = debug;
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

		engine.runRenderLoop(function() {
			scene.render();
		});
	}
};