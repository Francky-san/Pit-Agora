function changeStatut(obj) {
    if (selectionnes.indexOf(obj.id) == -1) {            // le créneau n'a pas le statut "sélectionné"
        if (profId(obj.id) != prof) {                           // soit première sélection, soit l'élève change de prof
            selectionnes.forEach(i => document.getElementById(i).className = "cellulePlanning dispo");
            selectionnes.splice(0,selectionnes.length,obj.id);
        }
        else {                                                  // on ajoute un creneau au prof sélectionné
            selectionnes.push(obj.id);
        }
        obj.className = "cellulePlanning selectionne";
        prof = profId(obj.id);
    }
    else {                                                      // le créneau a le statut "sélectionné"
        selectionnes.splice(selectionnes.indexOf(obj.id), 1);
        obj.className = "cellulePlanning dispo";
    }
    statutModifie = true;
    statut = obj.className;
}

function mOver(obj) {
    if (!statutModifie) {
        statut = obj.className;
        obj.className = "cellulePlanning survole";
    }
}

function mOut(obj) {
    obj.className = statut;
    statutModifie = false;
}

function profId(n) {
    return Math.round(n / 100);
}

function validerChoixCours() {
    document.getElementById("103").innerHTML = "Valider !";
}