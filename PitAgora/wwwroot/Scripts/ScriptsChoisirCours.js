function changerStatut(obj) {
    if (selectionnes.indexOf(obj.id) == -1) {            // le créneau n'a pas le statut "sélectionné"
        let profId = (document.getElementById(obj.id).parentElement.id).slice(1);   // On récupère l'Id du prof
        if (profId != prof) {           // soit première sélection, soit l'élève change de prof                
            selectionnes.forEach(i => document.getElementById(i).className = "cellulePlanning dispo");
            selectionnes.splice(0, selectionnes.length, obj.id);
        }
        else {                                                  // l'élève ajoute un creneau au prof sélectionné
            selectionnes.push(obj.id);
        }
        obj.className = "cellulePlanning selectionne";
        prof = profId;
        document.getElementById("retourProf").value = profId;
    }
    else {                                                      // le créneau a le statut "sélectionné"
        selectionnes.splice(selectionnes.indexOf(obj.id), 1);
        obj.className = "cellulePlanning dispo";
    }
 
    statut = obj.className;
    majRetour(selectionnes);
    let prix = calculerPrix(selectionnes.length, 0, false, false);  // test avec niveau scq, à domicile, en solo
    document.getElementById("prixCours").innerHTML = prix;
    document.getElementById("retourPrix").value = prix;

    if (SelectionValide() && prix <= parseFloat(document.getElementById("creditDispo").innerHTML)) {
        document.getElementById("boutonValider").disabled = false;
        document.getElementById("boutonValider").class = "BoutonValiderActif";
    }
    else {
        document.getElementById("boutonValider").disabled = true;
        document.getElementById("boutonValider").class = "BoutonValiderInactif";
    }
}

function mOver(obj) {
    //if (!statutModifie) {
        statut = obj.className;
        obj.className = "cellulePlanning survole";
    //}
}

function mOut(obj) {
    obj.className = statut;
    //statutModifie = false;
}

// Teste si la sélection de créneaux en cours est valide pour une réservation (consécutifs, au moins 2)
function SelectionValide() {
    let valid = true;
    if (selectionnes.length < 2) {
        valid = false;
    }
    else {
        selectionnes.sort();
        for (let k = 1; k < selectionnes.length; k++) {
            if (selectionnes[k] - selectionnes[k - 1] != 1) valid = false;
        }
    }
    return valid;
} 

// Place dans l'input caché une string contenant les Id des créneaux sélectionnés
function majRetour(selection) {
    let res = "";
    for (let id of selection) {
        res += id + ",";
    }
    document.getElementById("retourCreneaux").value = res;
}

// Demander confirmation avant d'envoyer la requête
function demanderConfirmation() {
    alert("test)")
    window.confirm("test1","test2")
}