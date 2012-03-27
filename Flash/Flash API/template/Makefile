MXMLC = mxmlc
LIB = lib/
SRC = src/Main.as  # Tous les autres fichiers .as
MAIN = Main.as # Fichier principal
SWF = Main.swf # Nom du fichier de sortie final
 
$(SWF) : $(SRC)
	$(MXMLC) -sp $(LIB) -o $(SWF) -- $(MAIN)