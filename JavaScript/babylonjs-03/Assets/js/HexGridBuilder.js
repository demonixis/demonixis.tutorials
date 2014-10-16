var HexGridBuilder = function (width, depth, margin) {
	this.width = width || 10;
	this.depth = depth || 10;
	this.margin = margin || 1.0;
	this._hexWidth = 1.0;
	this._hexDepth = 1.0;
	this._initialPosition = BABYLON.Vector3.Zero();
};

// Position initiale de la première tuile.
HexGridBuilder.prototype.calculateInitialPosition = function () {
	var position = BABYLON.Vector3.Zero();
	position.x = -this._hexWidth * this.width / 2.0 + this._hexWidth / 2.0;
	position.z = this.depth / 2.0 * this._hexDepth / 2.0;
	return position;
};

// Transforme des coordonnées "Hexa" en coordonnées 3D.
HexGridBuilder.prototype.getWorldCoordinate = function (x, y, z) {
	var offset = 0.0;
	
	if (z % 2 !== 0) {
		offset = this._hexWidth / 2.0;
	}
	
	var px = this._initialPosition.x + offset + x * this._hexWidth * this.margin;
	var pz = this._initialPosition.z - z * this._hexDepth * 0.75 * this.margin;

	return new BABYLON.Vector3(px, y, pz);
};

HexGridBuilder.prototype.generate = function (scene) {
	var grid = new BABYLON.Mesh("Grid", scene);
	grid.isVisible = false;
	
	var prefab = BABYLON.Mesh.CreateCylinder("cylinder", 1, 3, 3, 6, 1, scene, false);
	prefab.scaling = new BABYLON.Vector3(3, 3, 3);
	prefab.rotation.y += Math.PI / 6;
	
	var boundingInfo = prefab.getBoundingInfo();
	this._hexWidth = (boundingInfo.maximum.z - boundingInfo.minimum.z) * prefab.scaling.x;
	this._hexDepth = (boundingInfo.maximum.x - boundingInfo.minimum.x) * prefab.scaling.z;
	this._initialPosition = this.calculateInitialPosition();
	
	var materials = [
		new BABYLON.StandardMaterial("BlueMaterial", scene),
		new BABYLON.StandardMaterial("GreenMaterial", scene),
		new BABYLON.StandardMaterial("BrownMaterial", scene)
	];
	
	materials[0].diffuseTexture = new BABYLON.Texture("Assets/images/blue.png", scene);
	materials[1].diffuseTexture = new BABYLON.Texture("Assets/images/green.png", scene);
	materials[2].diffuseTexture = new BABYLON.Texture("Assets/images/brown.png", scene);
	
	var tile = null;
	var random = 0;
	
	for (var z = 0; z < this.depth; z++) {
		for (var x = 0; x < this.width; x++) {
			tile = prefab.clone();
			tile.position = this.getWorldCoordinate(x, 0, z);
			tile.hexPosition = new BABYLON.Vector3(x, 0, z);

			random = Math.floor(Math.random() * 10);
			
			if (random % 2 === 0) {
				tile.scaling.y += 1;
				tile.material = materials[0];
			}
			else if (random % 3 === 0) {
				tile.scaling.y += 6;
				tile.material = materials[2];
			}
			else {
				tile.material = materials[1];
			}
			
			tile.parent = grid;
		}
	} 
	
	prefab.dispose();
};