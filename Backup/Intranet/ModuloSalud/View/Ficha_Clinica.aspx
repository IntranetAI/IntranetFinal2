<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ficha_Clinica.aspx.cs"
    Inherits="Intranet.ModuloSalud.View.Ficha_Clinica" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"
        type="text/javascript"></script>
    <script type="text/javascript">
        function BuscarPaciente(RutPaciente) {
            $.ajax({
                url: "Ficha_Clinica.aspx/BuscarPaciente",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'Rut':'" + RutPaciente + "'}",
                success: function (msg) {
                    if (msg.d[0] != "") {
                        document.getElementById("txtRut").value = RutPaciente;
                        document.getElementById("txtRut").disabled = true;
                        document.getElementById("Nombre").value = msg.d[0];
                        document.getElementById("Nombre").disabled = true;
                        document.getElementById("txtFechaNacimiento").value = msg.d[1];
                        document.getElementById("txtFechaNacimiento").disabled = true;
                        document.getElementById("txtCargo").value = msg.d[2];
                        document.getElementById("txtCargo").disabled = true;
                        document.getElementById("txtAntiEmpresa").value = msg.d[4];
                        document.getElementById("txtAntiEmpresa").disabled = true;
                        document.getElementById("txtTelefono").value = msg.d[5];
                        document.getElementById("ddlCivil").value = msg.d[6];
                        document.getElementById("txtCalle").value = msg.d[7];
                        document.getElementById("txtComuna").value = msg.d[8];
                        document.getElementById("txtTurno").value = msg.d[9];
                        document.getElementById("txtTurno").disabled = true;
                        document.getElementById("ddlEmpresa").value = "Quad/Graphics";
                        document.getElementById("ddlEmpresa").disabled = true;
                        document.getElementById("txtCorreo").value = msg.d[11];
                        if (msg.d[10] == "Mujer") {
                            document.getElementById("ddlMamografia").style.display = "block";
                            document.getElementById("txtFechaMamo").style.display = "block";
                            document.getElementById("ddlPap").style.display = "block";
                            document.getElementById("txtFechaPap").style.display = "block";
                            document.getElementById("lblMamografia").style.display = "block";
                            document.getElementById("lblMamografiaFecha").style.display = "block";
                            document.getElementById("lblPap").style.display = "block";
                            document.getElementById("lblPapFecha").style.display = "block";
                            document.getElementById("txtEcoFecha").style.display = "block";
                            document.getElementById("ddlEco").style.display = "block";
                            document.getElementById("lblEco").style.display = "block";
                            document.getElementById("lblEcoFecha").style.display = "block";

                        }
                        else {
                            document.getElementById("ddlMamografia").style.display = "none";
                            document.getElementById("txtFechaMamo").style.display = "none";
                            document.getElementById("ddlPap").style.display = "none";
                            document.getElementById("txtFechaPap").style.display = "none";
                            document.getElementById("lblMamografia").style.display = "none";
                            document.getElementById("lblMamografiaFecha").style.display = "none";
                            document.getElementById("lblPap").style.display = "none";
                            document.getElementById("lblPapFecha").style.display = "none";
                            document.getElementById("txtEcoFecha").style.display = "none";
                            document.getElementById("ddlEco").style.display = "none";
                            document.getElementById("lblEco").style.display = "none";
                            document.getElementById("lblEcoFecha").style.display = "none";
                        }
                    }
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }

        function BuscarPaciente2(RutPaciente) {
            $.ajax({
                url: "Ficha_Clinica.aspx/BuscarPaciente2",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'Rut':'" + RutPaciente + "'}",
                success: function (msg) {
                    if (msg.d[0] != "") {
                        document.getElementById("txtRut").value = RutPaciente;
                        document.getElementById("txtRut").disabled = true;
                        document.getElementById("Nombre").value = msg.d[0];
                        document.getElementById("Nombre").disabled = true;
                        document.getElementById("txtFechaNacimiento").value = msg.d[1];
                        document.getElementById("txtFechaNacimiento").disabled = true;
                        document.getElementById("txtTelefono").value = msg.d[2];
                        document.getElementById("ddlCivil").value = msg.d[3];
                        document.getElementById("txtAnexo").value = msg.d[4];
                        document.getElementById("txtCorreo").value = msg.d[5];
                        document.getElementById("txtCalle").value = msg.d[6];
                        document.getElementById("txtComuna").value = msg.d[7];

                        document.getElementById("ddlTrasporter").value = msg.d[8];
                        document.getElementById("ddlEmpresa").value = msg.d[9];
                        document.getElementById("ddlEmpresa").disabled = true;
                        document.getElementById("txtCargo").value = msg.d[10];
                        document.getElementById("txtCargo").disabled = true;
                        document.getElementById("txtTurno").value = msg.d[11];
                        document.getElementById("txtTurno").disabled = true;
                        document.getElementById("txtAntiEmpresa").value = msg.d[13];
                        document.getElementById("txtAntiEmpresa").disabled = true;
                        document.getElementById("txtAntiCargo").value = msg.d[14];
                        document.getElementById("btn_Guardar").style.display = "none";
                        document.getElementById("DIVantecedentesMedicos").style.display = "none";


                        if (msg.d[12] == "Mujer") {
                            document.getElementById("ddlMamografia").style.display = "block";
                            document.getElementById("txtFechaMamo").style.display = "block";
                            document.getElementById("ddlPap").style.display = "block";
                            document.getElementById("txtFechaPap").style.display = "block";
                            document.getElementById("lblMamografia").style.display = "block";
                            document.getElementById("lblMamografiaFecha").style.display = "block";
                            document.getElementById("lblPap").style.display = "block";
                            document.getElementById("lblPapFecha").style.display = "block";
                            document.getElementById("txtEcoFecha").style.display = "block";
                            document.getElementById("ddlEco").style.display = "block";


                        }
                        else {
                            document.getElementById("ddlMamografia").style.display = "none";
                            document.getElementById("txtFechaMamo").style.display = "none";
                            document.getElementById("ddlPap").style.display = "none";
                            document.getElementById("txtFechaPap").style.display = "none";
                            document.getElementById("lblMamografia").style.display = "none";
                            document.getElementById("lblMamografiaFecha").style.display = "none";
                            document.getElementById("lblPap").style.display = "none";
                            document.getElementById("lblPapFecha").style.display = "none";
                            document.getElementById("txtEcoFecha").style.display = "none";
                            document.getElementById("ddlEco").style.display = "none";
                        }
                    }
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }

        function GuardarFicha(Rut, Telefono, FechaAnti) {
            var UsuarioCreador = '<%= Session["Usuario"] %>';
            var select = document.getElementById("ddlCivil");
            var EstadoCivil = select.options[select.selectedIndex].text;
            var select1 = document.getElementById("ddlTrasporter");
            var Transporte = select1.options[select1.selectedIndex].text;
            var select2 = document.getElementById("ddlEmpresa");
            var Empresa = select2.options[select2.selectedIndex].text;
            var Correo = document.getElementById("txtCorreo").value;
            var Anexo = document.getElementById("txtAnexo").value;

            $.ajax({
                url: "Ficha_Clinica.aspx/GuardarFicha",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'Rut':'" + Rut + "','Telefono':'" + Telefono + "','FechaAnti':'" + FechaAnti + "','EstadoCivil':'" + EstadoCivil + "','Transporte':'" + Transporte + "','Empresa':'" +
                        Empresa + "','Usuario':'" + UsuarioCreador + "','Correo':'" + Correo + "','Anexo':'" + Anexo + "'}",
                success: function (msg) {
                    if (msg.d[0] == "OK") {
                        GuardarConsulta(msg.d[1]);
                    }
                    else {
                        alert('¡Ha Ocurrido un Error al Crear la Ficha Medica! ');
                    }
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }

        function GuardarConsulta(ID_Ficha) {
            var IDFichaMedica = ID_Ficha;

            var Fuma = "No";
            var FumaCant = "";
            var FumaDescript = "";
            var porNombre = document.getElementsByName("rbFuma");
            for (var i = 0; i < porNombre.length; i++) {
                if (porNombre[i].checked) {
                    Fuma = porNombre[i].id.replace("rbFuma", "");
                    FumaCant = document.getElementById("txtfumaDiario").value;
                    FumaDescript = document.getElementById("txtfumaEspeci").value;
                }
            }
            var Bebe = "No";
            var BebeCant = "";
            var BebeDescript = "";
            porNombre = document.getElementsByName("rbBebe");
            for (var i = 0; i < porNombre.length; i++) {
                if (porNombre[i].checked) {
                    Bebe = porNombre[i].id.replace("rbBebe", "");
                    BebeCant = document.getElementById("txtBebeDiario").value;
                    BebeDescript = document.getElementById("txtBebeEspeci").value;
                }
            }
            var Drogas = "No";
            var DrogasCant = "";
            var DrogasCantDescript = "";
            porNombre = document.getElementsByName("rbDroga");
            for (var i = 0; i < porNombre.length; i++) {
                if (porNombre[i].checked) {
                    Drogas = porNombre[i].id.replace("rbDroga", "");
                    DrogasCant = document.getElementById("txtDrogaDiario").value;
                    DrogasCantDescript = document.getElementById("txtDrogaEspeci").value;
                }
            }
            var ActividadFisica = "No";
            var ActFCant = "";
            var ActFCantDescript = "";
            porNombre = document.getElementsByName("rbFisica");
            for (var i = 0; i < porNombre.length; i++) {
                if (porNombre[i].checked) {
                    ActividadFisica = porNombre[i].id.replace("rbFisica", "");
                    ActFCant = document.getElementById("txtFisicaDiario").value;
                    ActFCantDescript = document.getElementById("txtFisicaEspeci").value;
                }
            }
            var Medicamento_Alergia = "No";
            porNombre = document.getElementsByName("rbMedicAlergia");
            for (var i = 0; i < porNombre.length; i++) {
                if (porNombre[i].checked) {
                    Medicamento_Alergia = document.getElementById("txtMedAlerg").value;
                }
            }
            var Alimento_Alergia = "No";
            porNombre = document.getElementsByName("rbAlimalergia");
            for (var i = 0; i < porNombre.length; i++) {
                if (porNombre[i].checked) {
                    Alimento_Alergia = document.getElementById("txtAliAlerg").value;
                }
            }
            var Lentes = "No";
            porNombre = document.getElementsByName("rblentes");
            for (var i = 0; i < porNombre.length; i++) {
                if (porNombre[i].checked) {
                    Lentes = document.getElementById("txtlentes").value;
                }
            }
            var Audifonos = "No";
            porNombre = document.getElementsByName("rbaudifonos");
            for (var i = 0; i < porNombre.length; i++) {
                if (porNombre[i].checked) {
                    Audifonos = document.getElementById("txtaudifonos").value;
                }
            }
            var Protesis = "No";
            porNombre = document.getElementsByName("rbProtesis");
            for (var i = 0; i < porNombre.length; i++) {
                if (porNombre[i].checked) {
                    Protesis = document.getElementById("txtProtesis").value;
                }
            }
            var Plantillas = "No";
            porNombre = document.getElementsByName("rbPlantilla");
            for (var i = 0; i < porNombre.length; i++) {
                if (porNombre[i].checked) {
                    Plantillas = document.getElementById("txtPlantilla").value;
                }
            }
            var Medicamentos = "No";
            porNombre = document.getElementsByName("rbMedicamentos");
            for (var i = 0; i < porNombre.length; i++) {
                if (porNombre[i].checked) {
                    Medicamentos = document.getElementById("txtMedicamentos").value;
                }
            }
            var Intervenciones = "No";
            porNombre = document.getElementsByName("rbIntervencion");
            for (var i = 0; i < porNombre.length; i++) {
                if (porNombre[i].checked) {
                    Intervenciones = document.getElementById("txtIntervencion").value;
                }
            }
            var Enfermedad = "No";
            porNombre = document.getElementsByName("rbEnfermedad");
            for (var i = 0; i < porNombre.length; i++) {
                if (porNombre[i].checked) {
                    Enfermedad = document.getElementById("txtEnfermedad").value;
                }
            }
            var Dermatitis = "0";
            if (document.getElementById("ckbDermatitis").checked) {
                Dermatitis = "1";
            }

            var Varices = "0";
            if (document.getElementById("ckbVarices").checked) {
                Varices = "1";
            }
            var Epilepsia = "0";
            if (document.getElementById("ckEpilepsia").checked) {
                Epilepsia = "1";
            }
            var Sueño = "0";
            if (document.getElementById("ckSueño").checked) {
                Sueño = "1";
            }
            var Sangre = "0";
            if (document.getElementById("ckSangre").checked) {
                Sangre = "1";
            }
            var Neumonia = "0";
            if (document.getElementById("ckNeumonia").checked) {
                Neumonia = "1";
            }
            var Bronquitis = "0";
            if (document.getElementById("ckBronquitis").checked) {
                Bronquitis = "1";
            }
            var Ulceras = "0";
            if (document.getElementById("ckUlceras").checked) {
                Ulceras = "1";
            }
            var TBC = "0";
            if (document.getElementById("ckTBC").checked) {
                TBC = "1";
            }
            var Hepatitis = "0";
            if (document.getElementById("ckHepatitis").checked) {
                Hepatitis = "1";
            }
            var Asma = "0";
            if (document.getElementById("ckAsma").checked) {
                Asma = "1";
            }
            var Diabetes = "0";
            if (document.getElementById("ckDiabetes").checked) {
                Diabetes = "1";
            }
            var Fiebre = "0";
            if (document.getElementById("ckFiebre").checked) {
                Fiebre = "1";
            }
            var Hipertension = "0";
            if (document.getElementById("ckHipertension").checked) {
                Hipertension = "1";
            }
            var Lumbalgias = "0";
            if (document.getElementById("ckLumbalgias").checked) {
                Lumbalgias = "1";
            }
            var Tendinitis = "0";
            if (document.getElementById("ckTendinitis").checked) {
                Tendinitis = "1";
            }
            var Observacion = document.getElementById("txtObservaciones").value;

            var Pulso = document.getElementById("txtPulso").value;
            var Peso = document.getElementById("txtPeso").value;

            var select = document.getElementById("ddlMamografia");
            var Mamografia = select.options[select.selectedIndex].value;

            var FechaMamografia = document.getElementById("txtFechaMamo").value;
            var PresionArterial = document.getElementById("txtPresion").value;
            var Talla = document.getElementById("txtTalla").value;

            var select1 = document.getElementById("ddlPap");
            var Pap = select1.options[select1.selectedIndex].value;

            var FechaPap = document.getElementById("txtFechaPap").value;
            var Examen_CabezaCuello = document.getElementById("txtCabeza").value;
            var Examen_Torax = document.getElementById("txtTorax").value;
            var Examen_Abdomen = document.getElementById("txtAbdomen").value;
            var Examen_Urogenital = document.getElementById("txtUrogenital").value;
            var Extre_Superior = document.getElementById("txtSuperior").value;
            var Extre_Inferior = document.getElementById("txtInferior").value;
            var Columna = document.getElementById("txtColumna").value;
            var Diagnostico_Comun = document.getElementById("txtDiagnostico").value;
            var Diagnostico_Laboral = document.getElementById("txtDiagnosticoLaboral").value;
            var Diagnostico_Tratamiento = document.getElementById("txtTratamiento").value;
            var Diagnostico_Recomdacion = document.getElementById("txtRecomendaciones").value;
            var UsuarioCreador = '<%= Session["Usuario"] %>';

            var FechaControl = document.getElementById("txtControlFecha").value;
            var HoraControl = document.getElementById("txtControlHora").value;

            var select2 = document.getElementById("ddlAccidente");
            var TipoAccidente = select2.options[select2.selectedIndex].value;
            var polvo = "0";
            if (document.getElementById("cbxPolvo").checked) {
                polvo = "1";
            }
            var impacto = "0";
            if (document.getElementById("ckbImpacto").checked) {
                impacto = "1";
            }
            var permanente = "0";
            if (document.getElementById("cbxPermanente").checked) {
                permanente = "1";
            }
            var solvente = "0";
            if (document.getElementById("cbxSolvente").checked) {
                solvente = "1";
            }
            var mmc = "0";
            if (document.getElementById("cbxMMC").checked) {
                mmc = "1";
            }
            var sefp = "0";
            if (document.getElementById("cbxSEFP").checked) {
                sefp = "1";
            }
            var asmagenos = "0";
            if (document.getElementById("cbxAsmagenos").checked) {
                asmagenos = "1";
            }
            var calor = "0";
            if (document.getElementById("cbxCalor").checked) {
                calor = "1";
            }
            var ionizante = "0";
            if (document.getElementById("cbxIonizante").checked) {
                ionizante = "1";
            }
            var metales = "0";
            if (document.getElementById("cbxMetales").checked) {
                metales = "1";
            }
            var humo = "0";
            if (document.getElementById("cbxHumos").checked) {
                humo = "1";
            }
            var electromag = "0";
            if (document.getElementById("cbxElectromag").checked) {
                electromag = "1";
            }
            var riesgos = "0";
            if (document.getElementById("cbxRiesgos").checked) {
                riesgos = "1";
            }
            var Torax = "0";
            if (document.getElementById("cbxTorax").checked) {
                Torax = "1";
            }
            var Osea = "0";
            if (document.getElementById("cbxOsea").checked) {
                Osea = "1";
            }
            var Cavidades = "0";
            if (document.getElementById("cbxCavidades").checked) {
                Cavidades = "1";
            }
            var TAC = "0";
            if (document.getElementById("cbxTAC").checked) {
                TAC = "1";
            }
            var RNM = "0";
            if (document.getElementById("cbxRNM").checked) {
                RNM = "1";
            }
            var EEG = "0";
            if (document.getElementById("cbxEEG").checked) {
                EEG = "1";
            }
            var ECG = "0";
            if (document.getElementById("cbxECG").checked) {
                ECG = "1";
            }
            var ECARDG = "0";
            if (document.getElementById("cbxECARDG").checked) {
                ECARDG = "1";
            }
            var EMG = "0";
            if (document.getElementById("cbxEMG").checked) {
                EMG = "1";
            }
            var Laboratorio = document.getElementById("txtLaboratorio").value;


            var select2 = document.getElementById("ddlEco");
            var EcoMamaria = select2.options[select2.selectedIndex].value;

            var FechaEco = document.getElementById("txtEcoFecha").value;


            $.ajax({
                url: "Consulta_Medica.aspx/GuardarConsulta",
                type: "post",
                dataType: "json",
                contentType: "application/json;charset=utf-8",
                data: "{'IDFichaMedica':'" + IDFichaMedica + "',  'Fuma':'" + Fuma + "',  'Bebe':'" + Bebe + "',  'Drogas':'" + Drogas + "',  'ActividadFisica':'" + ActividadFisica + "',  'Medicamento_Alergia':'" +
                        Medicamento_Alergia + "',  'Alimento_Alergia':'" + Alimento_Alergia + "', 'Lentes':'" + Lentes + "', 'Audifonos':'" + Audifonos + "', 'Protesis':'" + Protesis + "', 'Plantillas':'" +
                        Plantillas + "', 'Medicamentos':'" + Medicamentos + "', 'Intervenciones':'" + Intervenciones + "', 'Enfermedad':'" + Enfermedad + "', 'Dermatitis':'" + Dermatitis + "', 'Varices':'" +
                        Varices + "', 'Epilepsia':'" + Epilepsia + "',  'Sueño':'" + Sueño + "',  'Sangre':'" + Sangre + "',  'Neumonia':'" + Neumonia + "',  'Bronquitis':'" + Bronquitis + "',  'Ulceras':'" +
                        Ulceras + "',  'TBC':'" + TBC + "',  'Hepatitis':'" + Hepatitis + "',  'Asma':'" + Asma + "',  'Diabetes':'" + Diabetes + "',  'Fiebre':'" + Fiebre + "',  'Hipertension':'" +
                        Hipertension + "',  'Lumbalgias':'" + Lumbalgias + "',  'Tendinitis':'" + Tendinitis + "',  'Observacion':'" + Observacion + "','UsuarioCreador':'" + UsuarioCreador +
                        "','FumaCant':'" + FumaCant + "','FumaDescript':'" + FumaDescript + "','BebeCant':'" + BebeCant + "','BebeDescript':'" + BebeDescript + "','DrogasCant':'" + DrogasCant + "','DrogasCantDescript':'" +
                        DrogasCantDescript + "','ActFCant':'" + ActFCant + "','ActFCantDescript':'" + ActFCantDescript +
                                 "','TipoAccidente':'" + TipoAccidente + "','polvo':'" + polvo + "','impacto':'" + impacto + "','permanente':'" + permanente + "','solvente':'" + solvente + "','mmc':'" + mmc + "','sefp':'" + sefp +
                                 "','asmagenos':'" + asmagenos + "','calor':'" + calor + "','ionizante':'" + ionizante + "','metales':'" + metales + "','humo':'" + humo + "','electromag':'" + electromag + "','riesgos':'" + riesgos +
                                  "','ddlEco':'" + EcoMamaria + "','txtEcoFecha':'" + FechaEco + "'}",
                success: function (msg) {
                    if (msg.d[0] == "OK") {
                        var IDAntMedicos = msg.d[1];
                        $.ajax({
                            url: "Consulta_Medica.aspx/GuardarConsultaPaciente",
                            type: "post",
                            dataType: "json",
                            contentType: "application/json;charset=utf-8",
                            data: "{'IDFichaMedica':'" + IDFichaMedica + "','Pulso':'" + Pulso + "','Peso':'" + Peso + "','Mamografia':'" + Mamografia + "','FechaMamografia':'" + FechaMamografia + "','PresionArterial':'" + PresionArterial +
                                 "','Talla':'" + Talla + "','Pap':'" + Pap + "','FechaPap':'" + FechaPap + "','Examen_CabezaCuello':'" + Examen_CabezaCuello + "','Examen_Torax':'" + Examen_Torax +
                                 "','Examen_Abdomen':'" + Examen_Abdomen + "','Examen_Urogenital':'" + Examen_Urogenital + "','Extre_Superior':'" + Extre_Superior + "','Extre_Inferior':'" + Extre_Inferior +
                                 "','Columna':'" + Columna + "','Diagnostico_Comun':'" + Diagnostico_Comun + "','Diagnostico_Laboral':'" + Diagnostico_Laboral + "','Diagnostico_Tratamiento':'" + Diagnostico_Tratamiento +
                                 "','Diagnostico_Recomdacion':'" + Diagnostico_Recomdacion + "','UsuarioCreador':'" + UsuarioCreador + "','FechaControl':'" + FechaControl + "','HoraControl':'" + HoraControl +
                                 "','Torax':'" + Torax + "','Osea':'" + Osea + "','Cavidades':'" + Cavidades + "','TAC':'" + TAC + "','RNM':'" + RNM + "','EEG':'" + EEG + "','ECG':'" + ECG + "','ECARDG':'" + ECARDG +
                                 "','EMG':'" + EMG + "','Laboratorio':'" + Laboratorio + "','IDAntMedicos':'" + IDAntMedicos + "'}",
                            success: function (msg) {
                                if (msg.d == "OK") { alert("¡Se a creado Correctamente!"); opener.location.reload(); window.close(); }
                                else { alert("¡Ha Ocurrido un Error!"); }
                            },
                            error: function () {
                                alert('¡Ha Ocurrido un Error!');
                            }
                        });
                    }
                    else {
                        alert('¡Ha Ocurrido un Error!');
                    }
                },
                error: function () {
                    alert('¡Ha Ocurrido un Error!');
                }
            });
        }


        $(document).ready(function () {

            $("#txtRut").change(function () {
                BuscarPaciente(this.value);
            });

            $('input[type=radio][name=rbFuma]').change(function () {
                if (this.id == 'rbFumaSi') {
                    document.getElementById("txtfumaDiario").disabled = false;
                    document.getElementById("txtfumaSemana").disabled = false;
                    document.getElementById("txtfumaMensal").disabled = false;
                    document.getElementById("txtfumaEspeci").disabled = false;
                }
                else {
                    document.getElementById("txtfumaDiario").disabled = true;
                    document.getElementById("txtfumaSemana").disabled = true;
                    document.getElementById("txtfumaMensal").disabled = true;
                    document.getElementById("txtfumaEspeci").disabled = true;
                }
            });

            $('input[type=radio][name=rbBebe]').change(function () {
                if (this.id == 'rbBebeSi') {
                    document.getElementById("txtBebeDiario").disabled = false;
                    document.getElementById("txtBebeSemana").disabled = false;
                    document.getElementById("txtBebeMensua").disabled = false;
                    document.getElementById("txtBebeEspeci").disabled = false;
                }
                else {
                    document.getElementById("txtBebeDiario").disabled = true;
                    document.getElementById("txtBebeSemana").disabled = true;
                    document.getElementById("txtBebeMensua").disabled = true;
                    document.getElementById("txtBebeEspeci").disabled = true;
                }
            });

            $('input[type=radio][name=rbDroga]').change(function () {
                if (this.id == 'rbDrogaSi') {
                    document.getElementById("txtDrogaDiario").disabled = false;
                    document.getElementById("txtDrogaSemana").disabled = false;
                    document.getElementById("txtDrogaMensua").disabled = false;
                    document.getElementById("txtDrogaEspeci").disabled = false;
                }
                else {
                    document.getElementById("txtDrogaDiario").disabled = true;
                    document.getElementById("txtDrogaSemana").disabled = true;
                    document.getElementById("txtDrogaMensua").disabled = true;
                    document.getElementById("txtDrogaEspeci").disabled = true;
                }
            });

            $('input[type=radio][name=rbFisica]').change(function () {
                if (this.id == 'rbFisicaSi') {
                    document.getElementById("txtFisicaDiario").disabled = false;
                    document.getElementById("txtFisicaSemana").disabled = false;
                    document.getElementById("txtFisicaMensua").disabled = false;
                    document.getElementById("txtFisicaEspeci").disabled = false;
                }
                else {
                    document.getElementById("txtFisicaDiario").disabled = true;
                    document.getElementById("txtFisicaSemana").disabled = true;
                    document.getElementById("txtFisicaMensua").disabled = true;
                    document.getElementById("txtFisicaEspeci").disabled = true;
                }
            });

            $('input[type=radio][name=rbMedicAlergia]').change(function () {
                if (this.id == 'rbMedAlergSi') {
                    document.getElementById("txtMedAlerg").disabled = false;
                    document.getElementById("cbxPolvo").disabled = false;
                    document.getElementById("ckbImpacto").disabled = false;
                    document.getElementById("cbxPermanente").disabled = false;
                }
                else {
                    document.getElementById("txtMedAlerg").disabled = true;
                    document.getElementById("cbxPolvo").disabled = true;
                    document.getElementById("ckbImpacto").disabled = true;
                    document.getElementById("cbxPermanente").disabled = true;
                }
            });

            $('input[type=radio][name=rbMedicamentos]').change(function () {
                if (this.id == 'rbMedicamentosSi') {
                    document.getElementById("txtMedicamentos").disabled = false;
                }
                else {
                    document.getElementById("txtMedicamentos").disabled = true;
                }
            });

            $('input[type=radio][name=rbPlantilla]').change(function () {
                if (this.id == 'rbPlantillaSi') {
                    document.getElementById("txtPlantilla").disabled = false;
                }
                else {
                    document.getElementById("txtPlantilla").disabled = true;
                }
            });

            $('input[type=radio][name=rbProtesis]').change(function () {
                if (this.id == 'rbProtesisSi') {
                    document.getElementById("txtProtesis").disabled = false;
                }
                else {
                    document.getElementById("txtProtesis").disabled = true;
                }
            });

            $('input[type=radio][name=rbaudifonos]').change(function () {
                if (this.id == 'rbaudifonosSi') {
                    document.getElementById("txtaudifonos").disabled = false;
                }
                else {
                    document.getElementById("txtaudifonos").disabled = true;
                }
            });

            $('input[type=radio][name=rblentes]').change(function () {
                if (this.id == 'rblentesSi') {
                    document.getElementById("txtlentes").disabled = false;
                    document.getElementById("cbxMetales").disabled = false;
                    document.getElementById("cbxHumos").disabled = false;
                    document.getElementById("cbxElectromag").disabled = false;
                    document.getElementById("cbxRiesgos").disabled = false;

                }
                else {
                    document.getElementById("txtlentes").disabled = true;
                    document.getElementById("cbxMetales").disabled = true;
                    document.getElementById("cbxHumos").disabled = true;
                    document.getElementById("cbxElectromag").disabled = true;
                    document.getElementById("cbxRiesgos").disabled = true;
                }
            });

            $('input[type=radio][name=rbAlimalergia]').change(function () {
                if (this.id == 'rbAliAlergSi') {
                    document.getElementById("txtAliAlerg").disabled = false;

                    document.getElementById("cbxSolvente").disabled = false;
                    document.getElementById("cbxMMC").disabled = false;
                    document.getElementById("cbxSEFP").disabled = false;
                    document.getElementById("cbxAsmagenos").disabled = false;
                    document.getElementById("cbxCalor").disabled = false;
                    document.getElementById("cbxIonizante").disabled = false;
                }
                else {
                    document.getElementById("txtAliAlerg").disabled = true;
                    document.getElementById("cbxSolvente").disabled = true;
                    document.getElementById("cbxMMC").disabled = true;
                    document.getElementById("cbxSEFP").disabled = true;
                    document.getElementById("cbxAsmagenos").disabled = true;
                    document.getElementById("cbxCalor").disabled = true;
                    document.getElementById("cbxIonizante").disabled = true;
                }
            });

            $('input[type=radio][name=rbIntervencion]').change(function () {
                if (this.id == 'rbIntervencionSi') {
                    document.getElementById("txtIntervencion").disabled = false;
                }
                else {
                    document.getElementById("txtIntervencion").disabled = true;
                }
            });

            $('input[type=radio][name=rbEnfermedad]').change(function () {
                if (this.id == 'rbEnfermedadSi') {
                    document.getElementById("txtEnfermedad").disabled = false;
                }
                else {
                    document.getElementById("txtEnfermedad").disabled = true;
                }
            });

            $("input[type='text'][id=txtTalla]").change(function () {
                var Peso = document.getElementById("txtPeso").value;
                var altura = document.getElementById("txtTalla").value;
                if (Peso != "" && altura != "") {
                    var IMC = (eval(Peso) / ((eval(altura) / 100) * (eval(altura) / 100)));
                    document.getElementById("txtIMC").value = IMC.toFixed();
                }
                else {
                    document.getElementById("txtIMC").value = "";
                }
            });

            $("input[type='text'][id=txtPeso]").change(function () {
                var Peso = document.getElementById("txtPeso").value;
                var altura = document.getElementById("txtTalla").value;
                if (Peso != "" && altura != "") {
                    var IMC = (eval(Peso) / ((eval(altura) / 100) * (eval(altura) / 100)));
                    document.getElementById("txtIMC").value = IMC.toFixed();
                }
                else {
                    document.getElementById("txtIMC").value = "";
                }
            });

        }); 
    </script>
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal" role="form">
    <div class="container">
        <div class="panel-group" id="accordion">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse1">Identificación</a></h3>
                </div>
                <div id="collapse1" class="panel-collapse  collapse  in">
                    <div class="panel-body">
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="txtRut">
                                C.I.:</label>
                            <div class="col-sm-2">
                                <input id="txtRut" class="form-control" type="text" placeholder="C:I." />
                            </div>
                            <label class="control-label col-sm-2" for="Nombre">
                                Nombre:</label>
                            <div class="col-sm-6">
                                <input id="Nombre" class="form-control" type="text" placeholder="Nombre Paciente" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="txtFechaNacimiento">
                                Fecha Nac.:</label>
                            <div class="col-sm-2">
                                <input id="txtFechaNacimiento" class="form-control text-right" type="text" placeholder="Fecha Nac." />
                            </div>
                            <label class="control-label col-sm-2" for="txtTelefono">
                                Telefono:</label>
                            <div class="col-sm-2">
                                <input id="txtTelefono" class="form-control text-right" type="text" placeholder="Telefono" />
                            </div>
                            <label class="control-label col-sm-2" for="ddlCivil">
                                Estado Civil:</label>
                            <div class="col-sm-2">
                                <select id="ddlCivil" class="form-control">
                                    <option>Seleccionar</option>
                                    <option>Casado(a)</option>
                                    <option>Soltero(a)</option>
                                    <option>Viudo(a)</option>
                                    <option>Separado(a)</option>
                                </select>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="txtAnexo">
                                Anexo:</label>
                            <div class="col-sm-2">
                                <input id="txtAnexo" class="form-control text-right" type="text" placeholder="Anexo" />
                            </div>
                            <label class="control-label col-sm-2" for="txtCorreo">
                                Correo:</label>
                            <div class="col-sm-6">
                                <input id="txtCorreo" class="form-control" type="text" placeholder="Correo" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="btn-group pull-right" style="margin-right: 15px;" role="group">
                                <button type="button" class="btn btn-default" data-toggle="collapse" data-parent="#accordion"
                                    href="#collapse2">
                                    Siguiente</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse2">Dirección</a></h3>
                </div>
                <div id="collapse2" class="panel-collapse collapse">
                    <div class="panel-body">
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="txtCalle">
                                Calle:</label>
                            <div class="col-sm-6">
                                <input id="txtCalle" class="form-control" type="text" placeholder="Calle" />
                            </div>
                            <label class="control-label col-sm-2" for="txtComuna">
                                Comuna:</label>
                            <div class="col-sm-2">
                                <input id="txtComuna" class="form-control" type="text" placeholder="Comuna" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2" for="ddlTrasporter">
                                Tipo Trasporte:</label>
                            <div class="col-sm-3">
                                <select id="ddlTrasporter" class="form-control">
                                    <option>Seleccionar</option>
                                    <option>Automovil</option>
                                    <option>Moto</option>
                                    <option>Camioneta</option>
                                    <option>Micro</option>
                                    <option>Micro + Metro</option>
                                    <option>Bus Aprox</option>
                                    <option>Bus Aprox + Colectivo</option>
                                    <option>Bus Aprox + Micro</option>
                                    <option>Bicicleta</option>
                                    <option>Caminar</option>
                                </select>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="btn-group pull-right" style="margin-right: 15px;" role="group">
                                <button type="button" class="btn btn-default" data-toggle="collapse" data-parent="#accordion"
                                    href="#collapse1">
                                    Anterior</button>
                                <button type="button" class="btn btn-default" data-toggle="collapse" data-parent="#accordion"
                                    href="#collapse3">
                                    Siguiente</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse3">Información Laboral</a></h3>
                </div>
                <div id="collapse3" class="panel-collapse collapse">
                    <div class="panel-body">
                        <div class="form-group">
                            <label class="control-label col-sm-1" for="ddlEmpresa">
                                Empresa:</label>
                            <div class="col-sm-3">
                                <select id="ddlEmpresa" class="form-control">
                                    <option>Seleccionar</option>
                                    <option>Quad/Graphics</option>
                                    <option>Externo</option>
                                </select>
                            </div>
                            <label class="control-label col-sm-2" for="txtCargo">
                                Cargo:</label>
                            <div class="col-sm-4">
                                <input id="txtCargo" class="form-control" type="text" placeholder="Cargo" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-1" for="txtTurno">
                                Turno:</label>
                            <div class="col-sm-3">
                                <input id="txtTurno" class="form-control" type="text" placeholder="Turno" />
                            </div>
                            <label class="control-label col-sm-2" for="txtAntiCargo">
                                Antig. Cargo:</label>
                            <div class="col-sm-2">
                                <input id="txtAntiCargo" class="form-control text-right" type="text" placeholder="Antig. Cargo" />
                            </div>
                            <label class="control-label col-sm-2" for="txtAntiEmpresa">
                                Antig. Empresa:</label>
                            <div class="col-sm-2">
                                <input id="txtAntiEmpresa" class="form-control text-right" type="text" placeholder="Antig. Empresa" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="btn-group pull-right" style="margin-right: 15px;" role="group">
                                <button type="button" class="btn btn-default" data-toggle="collapse" data-parent="#accordion"
                                    href="#collapse2">
                                    Anterior</button>
                                <button type="button" class="btn btn-default" data-toggle="collapse" data-parent="#accordion"
                                    href="#collapse6">
                                    Siguiente</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%--<div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse4">Información Familiares</a></h3>
                </div>
                <div id="collapse4" class="panel-collapse collapse">
                    <div class="panel-body">
                        <div class="form-group">
                            <label class="control-label col-sm-1" for="ddlEmpresa">
                                Familiar:</label>
                            <div class="col-sm-3">
                                <input id="txtFamiliar" class="form-control text-right" type="text" placeholder="Familiar" />
                            </div>
                            <label class="control-label col-sm-2" for="txtCargo">
                                Enfermedad:</label>
                            <div class="col-sm-4">
                                <input id="Text8" class="form-control" type="text" placeholder="Enfermedad" />
                            </div>
                            
                        </div>
                        <div class="form-group">
                            <div class="btn-group pull-right" style="margin-right: 15px;" role="group">
                                <button type="button" class="btn btn-default" data-toggle="collapse" data-parent="#accordion"
                                    href="#collapse3">
                                    Anterior</button>
                                <button type="button" class="btn btn-default" data-toggle="collapse" data-parent="#accordion"
                                    href="#collapse5">
                                    Siguiente</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse5">Antecedentes Siniestralidad Laboral</a></h3>
                </div>
                <div id="collapse5" class="panel-collapse collapse">
                    <div class="panel-body">
                        <div class="form-group">
                            <label class="control-label col-sm-1" for="ddlEmpresa">
                                Empresa:</label>
                            <div class="col-sm-3">
                                <select id="Select2" class="form-control">
                                    <option>Seleccionar</option>
                                    <option>Quad/Graphics</option>
                                    <option>Externo</option>
                                </select>
                            </div>
                            <label class="control-label col-sm-2" for="txtCargo">
                                Cargo:</label>
                            <div class="col-sm-4">
                                <input id="Text12" class="form-control" type="text" placeholder="Cargo" />
                            </div>
                            
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-1" for="txtTurno">
                                Turno:</label>
                            <div class="col-sm-3">
                                <input id="Text13" class="form-control" type="text" placeholder="Turno" />
                            </div>
                            <label class="control-label col-sm-2" for="txtAntiCargo">
                                Antig. Cargo:</label>
                            <div class="col-sm-2">
                                <input id="Text14" class="form-control text-right" type="text" placeholder="Antig. Cargo" />
                            </div>
                            <label class="control-label col-sm-2" for="txtAntiEmpresa">
                                Antig. Empresa:</label>
                            <div class="col-sm-2">
                                <input id="Text15" class="form-control text-right" type="text" placeholder="Antig. Empresa" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="btn-group pull-right" style="margin-right: 15px;" role="group">
                                <button type="button" class="btn btn-default" data-toggle="collapse" data-parent="#accordion"
                                    href="#collapse4">
                                    Anterior</button>
                                <button type="button" class="btn btn-default" data-toggle="collapse" data-parent="#accordion"
                                    href="#collapse6">
                                    Siguiente</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>--%>
            <div id="DIVantecedentesMedicos" class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">
                        <a data-toggle="collapse" data-parent="#accordion" href="#collapse6">Antecedentes Medicos</a></h3>
                </div>
                <div id="collapse6" class="panel-collapse collapse">
                    <div class="panel-body">
                        <ul class="nav nav-tabs">
                            <li class="active"><a data-toggle="tab" href="#home">Hábitos</a></li>
                            <li><a data-toggle="tab" href="#menu1">Antecedentes Generales</a></li>
                            <li><a data-toggle="tab" href="#menu2">Antecedentes Laborales</a></li>
                            <li><a data-toggle="tab" href="#menu3">Antecedentes Morbilidad</a></li>
                            <li><a data-toggle="tab" href="#menu4">Examen Fisico</a></li>
                            <li><a data-toggle="tab" href="#menu5">Tratamiento</a></li>
                        </ul>
                        <div class="tab-content">
                            <div id="home" class="tab-pane fade in active">
                                <h3>
                                    Hábitos</h3>
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                Si
                                            </td>
                                            <td>
                                                No
                                            </td>
                                            <td>
                                                Diario
                                            </td>
                                            <td>
                                                Semanal
                                            </td>
                                            <td>
                                                Mensual
                                            </td>
                                            <td>
                                                Especificar
                                            </td>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>
                                                Fuma
                                            </td>
                                            <td>
                                                <input id="rbFumaSi" type="radio" value="" name="rbFuma" />
                                            </td>
                                            <td>
                                                <input id="rbFumaNo" type="radio" value="" name="rbFuma" />
                                            </td>
                                            <td>
                                                <input id="txtfumaDiario" class="form-control" type="text" placeholder="Cantidad Diario" />
                                            </td>
                                            <td>
                                                <input id="txtfumaSemana" class="form-control" type="text" placeholder="Cantidad Semanal" />
                                            </td>
                                            <td>
                                                <input id="txtfumaMensal" class="form-control" type="text" placeholder="Cantidad Mensual" />
                                            </td>
                                            <td>
                                                <input id="txtfumaEspeci" class="form-control" type="text" placeholder="Especificar" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Bebe(Alcohol)
                                            </td>
                                            <td>
                                                <input id="rbBebeSi" type="radio" value="" name="rbBebe" />
                                            </td>
                                            <td>
                                                <input id="rbBebeNo" type="radio" value="" name="rbBebe" />
                                            </td>
                                            <td>
                                                <input id="txtBebeDiario" class="form-control" type="text" placeholder="Cantidad Diario" />
                                            </td>
                                            <td>
                                                <input id="txtBebeSemana" class="form-control" type="text" placeholder="Cantidad Semanal" />
                                            </td>
                                            <td>
                                                <input id="txtBebeMensua" class="form-control" type="text" placeholder="Cantidad Mensual" />
                                            </td>
                                            <td>
                                                <input id="txtBebeEspeci" class="form-control" type="text" placeholder="Especificar" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Drogas
                                            </td>
                                            <td>
                                                <input id="rbDrogaSi" type="radio" value="" name="rbDroga" />
                                            </td>
                                            <td>
                                                <input id="rbDrogaNo" type="radio" value="" name="rbDroga" />
                                            </td>
                                            <td>
                                                <input id="txtDrogaDiario" class="form-control" type="text" placeholder="Cantidad Diario" />
                                            </td>
                                            <td>
                                                <input id="txtDrogaSemana" class="form-control" type="text" placeholder="Cantidad Semanal" />
                                            </td>
                                            <td>
                                                <input id="txtDrogaMensua" class="form-control" type="text" placeholder="Cantidad Mensual" />
                                            </td>
                                            <td>
                                                <input id="txtDrogaEspeci" class="form-control" type="text" placeholder="Especificar" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Act. Fisica
                                            </td>
                                            <td>
                                                <input id="rbFisicaSi" type="radio" value="" name="rbFisica" />
                                            </td>
                                            <td>
                                                <input id="rbFisicaNo" type="radio" value="" name="rbFisica" />
                                            </td>
                                            <td>
                                                <input id="txtFisicaDiario" class="form-control" type="text" placeholder="Cantidad Diario" />
                                            </td>
                                            <td>
                                                <input id="txtFisicaSemana" class="form-control" type="text" placeholder="Cantidad Semanal" />
                                            </td>
                                            <td>
                                                <input id="txtFisicaMensua" class="form-control" type="text" placeholder="Cantidad Mensual" />
                                            </td>
                                            <td>
                                                <input id="txtFisicaEspeci" class="form-control" type="text" placeholder="Especificar" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div id="menu1" class="tab-pane fade">
                                <h3>
                                    Antecedentes Generales</h3>
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                Si
                                            </td>
                                            <td>
                                                No
                                            </td>
                                            <td>
                                                Cuál/Tipo
                                            </td>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>
                                                Medicamentos que le producen alergia
                                            </td>
                                            <td>
                                                <input id="rbMedAlergSi" type="radio" value="" name="rbMedicAlergia" />
                                            </td>
                                            <td>
                                                <input id="rbMedAlergNo" type="radio" value="" name="rbMedicAlergia" />
                                            </td>
                                            <td>
                                                <input id="txtMedAlerg" class="form-control" type="text" placeholder="Cuál/Tipo" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Alimentos que le producen alergia
                                            </td>
                                            <td>
                                                <input id="rbAliAlergSi" type="radio" value="" name="rbAlimalergia" />
                                            </td>
                                            <td>
                                                <input id="rbAliAlergNo" type="radio" value="" name="rbAlimalergia" />
                                            </td>
                                            <td>
                                                <input id="txtAliAlerg" class="form-control" type="text" placeholder="Cuál/Tipo" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Usa Lentes
                                            </td>
                                            <td>
                                                <input id="rblentesSi" type="radio" value="" name="rblentes" />
                                            </td>
                                            <td>
                                                <input id="rblentesNo" type="radio" value="" name="rblentes" />
                                            </td>
                                            <td>
                                                <input id="txtlentes" class="form-control" type="text" placeholder="Cuál/Tipo" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Usa Audífonos
                                            </td>
                                            <td>
                                                <input id="rbaudifonosSi" type="radio" value="" name="rbaudifonos" />
                                            </td>
                                            <td>
                                                <input id="rbaudifonosNo" type="radio" value="" name="rbaudifonos" />
                                            </td>
                                            <td>
                                                <input id="txtaudifonos" class="form-control" type="text" placeholder="Cuál/Tipo" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Usa Prótesis
                                            </td>
                                            <td>
                                                <input id="rbProtesisSi" type="radio" value="" name="rbProtesis" />
                                            </td>
                                            <td>
                                                <input id="rbProtesisNo" type="radio" value="" name="rbProtesis" />
                                            </td>
                                            <td>
                                                <input id="txtProtesis" class="form-control" type="text" placeholder="Cuál/Tipo" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Usa Plantillas Ortopédicas
                                            </td>
                                            <td>
                                                <input id="rbPlantillaSi" type="radio" value="" name="rbPlantilla" />
                                            </td>
                                            <td>
                                                <input id="rbPlantillaNo" type="radio" value="" name="rbPlantilla" />
                                            </td>
                                            <td>
                                                <input id="txtPlantilla" class="form-control" type="text" placeholder="Cuál/Tipo" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Usa Medicamentos
                                            </td>
                                            <td>
                                                <input id="rbMedicamentosSi" type="radio" value="" name="rbMedicamentos" />
                                            </td>
                                            <td>
                                                <input id="rbMedicamentosNo" type="radio" value="" name="rbMedicamentos" />
                                            </td>
                                            <td>
                                                <textarea id="txtMedicamentos" class="form-control" rows="2" cols="1" placeholder="Cuál/Tipo"></textarea>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div id="menu2" class="tab-pane fade">
                                <h3>
                                    Antecedentes Laborales</h3>
                                <div class="form-group">
                                    <label class="control-label col-sm-3" for="txtRut">
                                        Tipo de Accidente:</label>
                                    <div class="col-sm-4">
                                        <select id="ddlAccidente" class="form-control">
                                            <option>Seleccionar</option>
                                            <option>Trabajo CTP</option>
                                            <option>Trabajo STP</option>
                                            <option>Trabajo Tray</option>
                                            <option>Hogar</option>
                                            <option>Comunes</option>
                                        </select>
                                    </div>
                                </div>
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                Expuesto a
                                            </td>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>
                                                Medicamentos que le producen alergia
                                            </td>
                                            <td>
                                                <div class="form-group">
                                                    <div class="col-sm-2">
                                                        <label class="checkbox-inline">
                                                            <input id="cbxPolvo" type="checkbox" value="" />Polvo</label>
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <label class="checkbox-inline">
                                                            <input id="ckbImpacto" type="checkbox" value="" />Ruido Impacto</label>
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <label class="checkbox-inline">
                                                            <input id="cbxPermanente" type="checkbox" value="" />Ruido permanente
                                                        </label>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Alimentos que le producen alergia
                                            </td>
                                            <td>
                                                <div class="form-group">
                                                    <div class="col-sm-2">
                                                        <label class="checkbox-inline">
                                                            <input id="cbxSolvente" type="checkbox" value="" />Solventes</label>
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <label class="checkbox-inline">
                                                            <input id="cbxMMC" type="checkbox" value="" />MMC</label>
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <label class="checkbox-inline">
                                                            <input id="cbxSEFP" type="checkbox" value="" />SEFP</label>
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <label class="checkbox-inline">
                                                            <input id="cbxAsmagenos" type="checkbox" value="" />Asmagenos</label>
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <label class="checkbox-inline">
                                                            <input id="cbxCalor" type="checkbox" value="" />Calor</label>
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <label class="checkbox-inline">
                                                            <input id="cbxIonizante" type="checkbox" value="" />Radiacion Ionizante</label>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Usa Lentes
                                            </td>
                                            <td>
                                                <div class="form-group">
                                                    <div class="col-sm-3">
                                                        <label class="checkbox-inline">
                                                            <input id="cbxMetales" type="checkbox" value="" />Metales Pesados</label>
                                                    </div>
                                                    <div class="col-sm-3">
                                                        <label class="checkbox-inline">
                                                            <input id="cbxHumos" type="checkbox" value="" />Humos Metalicos</label>
                                                    </div>
                                                    <div class="col-sm-2">
                                                        <label class="checkbox-inline">
                                                            <input id="cbxElectromag" type="checkbox" value="" />Electromag</label>
                                                    </div>
                                                    <div class="col-sm-3">
                                                        <label class="checkbox-inline">
                                                            <input id="cbxRiesgos" type="checkbox" value="" />Riesgos Psic-Soc</label>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div id="menu3" class="tab-pane fade">
                                <h3>
                                    Antecedentes Morbilidad</h3>
                                <table class="table">
                                    <thead>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                Si
                                            </td>
                                            <td>
                                                No
                                            </td>
                                            <td>
                                                Cuál/Tipo
                                            </td>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>
                                                Intervenciones Quirúrgicas
                                            </td>
                                            <td>
                                                <input id="rbIntervencionSi" type="radio" value="" name="rbIntervencion" />
                                            </td>
                                            <td>
                                                <input id="rbIntervencionNo" type="radio" value="" name="rbIntervencion" />
                                            </td>
                                            <td>
                                                <textarea id="txtIntervencion" class="form-control" rows="2" cols="1" placeholder="Cuál/Tipo"></textarea>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Enfermedades Importantes
                                            </td>
                                            <td>
                                                <input id="rbEnfermedadSi" type="radio" value="" name="rbEnfermedad" />
                                            </td>
                                            <td>
                                                <input id="rbEnfermedadNo" type="radio" value="" name="rbEnfermedad" />
                                            </td>
                                            <td>
                                                <input id="txtEnfermedad" class="form-control" type="text" placeholder="Cuál/Tipo" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <div class="form-group">
                                    <div class="col-sm-2">
                                        <label class="checkbox-inline">
                                            <input id="ckbDermatitis" type="checkbox" value="" />Dermatitis</label>
                                    </div>
                                    <div class="col-sm-2">
                                        <label class="checkbox-inline">
                                            <input id="ckbVarices" type="checkbox" value="" />Várices</label>
                                    </div>
                                    <div class="col-sm-2">
                                        <label class="checkbox-inline">
                                            <input id="ckEpilepsia" type="checkbox" value="" />Epilepsia</label>
                                    </div>
                                    <div class="col-sm-2">
                                        <label class="checkbox-inline">
                                            <input id="ckSueño" type="checkbox" value="" />Trastornos del Sueño</label>
                                    </div>
                                    <div class="col-sm-2">
                                        <label class="checkbox-inline">
                                            <input id="ckSangre" type="checkbox" value="" />Alteraciones Sangre</label>
                                    </div>
                                    <div class="col-sm-2">
                                        <label class="checkbox-inline">
                                            <input id="ckNeumonia" type="checkbox" value="" />Neumonía</label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-2">
                                        <label class="checkbox-inline">
                                            <input id="ckBronquitis" type="checkbox" value="" />Bonquítis Cronica</label>
                                    </div>
                                    <div class="col-sm-2">
                                        <label class="checkbox-inline">
                                            <input id="ckUlceras" type="checkbox" value="" />Úlceras Gástricas</label>
                                    </div>
                                    <div class="col-sm-2">
                                        <label class="checkbox-inline">
                                            <input id="ckTBC" type="checkbox" value="" />TBC</label>
                                    </div>
                                    <div class="col-sm-2">
                                        <label class="checkbox-inline">
                                            <input id="ckHepatitis" type="checkbox" value="" />Hepatitis</label>
                                    </div>
                                    <div class="col-sm-2">
                                        <label class="checkbox-inline">
                                            <input id="ckAsma" type="checkbox" value="" />Asma</label>
                                    </div>
                                    <div class="col-sm-2">
                                        <label class="checkbox-inline">
                                            <input id="ckDiabetes" type="checkbox" value="" />Diabetes Mellitus</label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-2">
                                        <label class="checkbox-inline">
                                            <input id="ckFiebre" type="checkbox" value="" />Fiebre Tifoidea</label>
                                    </div>
                                    <div class="col-sm-2">
                                        <label class="checkbox-inline">
                                            <input id="ckHipertension" type="checkbox" value="" />Hipertensión Arterial</label>
                                    </div>
                                    <div class="col-sm-2">
                                        <label class="checkbox-inline">
                                            <input id="ckLumbalgias" type="checkbox" value="" />Lumbalgias</label>
                                    </div>
                                    <div class="col-sm-2">
                                        <label class="checkbox-inline">
                                            <input id="ckTendinitis" type="checkbox" value="" />Tendinitis
                                        </label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-2" for="txtObservaciones">
                                        Observaciones:</label>
                                    <div class="col-sm-10">
                                        <textarea id="txtObservaciones" class="form-control" rows="2" cols="1" placeholder="Observaciones"></textarea>
                                    </div>
                                </div>
                            </div>
                            
                            <div id="menu4" class="tab-pane fade">
                                <h3>
                                    Examen Fisico</h3>
                                <div class="form-group">
                                    <label class="control-label col-sm-1" for="txtPulso">
                                        Pulso:</label>
                                    <div class="col-sm-2">
                                        <input id="txtPulso" class="form-control" type="text" placeholder="Pulso" />
                                    </div>
                                    <label class="control-label col-sm-1" for="txtPresion">
                                        Presión Arterial:</label>
                                    <div class="col-sm-2">
                                        <input id="txtPresion" class="form-control" type="text" placeholder="Presión Arterial" />
                                    </div>
                                    <label id="lblMamografia" class="control-label col-sm-1" for="ddlMamografia">
                                        Mamografia:</label>
                                    <div class="col-sm-2">
                                        <select id="ddlMamografia" class="form-control">
                                            <option>No</option>
                                            <option>Si</option>
                                        </select>
                                    </div>
                                    <label id="lblMamografiaFecha" class="control-label col-sm-1" for="txtFechaMamo">
                                        Fecha:</label>
                                    <div class="col-sm-2">
                                        <input id="txtFechaMamo" class="form-control" type="text" placeholder="Fecha" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-1" for="txtPeso">
                                        Peso:</label>
                                    <div class="col-sm-2">
                                        <input id="txtPeso" class="form-control" type="text" placeholder="Peso" />
                                    </div>
                                    <label class="control-label col-sm-1" for="txtTalla">
                                        Talla:</label>
                                    <div class="col-sm-2">
                                        <input id="txtTalla" class="form-control" type="text" placeholder="Talla" />
                                    </div>
                                    <label id="lblPap" class="control-label col-sm-1" for="ddlPap">
                                        PAP:</label>
                                    <div class="col-sm-2">
                                        <select id="ddlPap" class="form-control">
                                            <option>No</option>
                                            <option>Si</option>
                                        </select>
                                    </div>
                                    <label id="lblPapFecha" class="control-label col-sm-1" for="txtFechaPap">
                                        Fecha:</label>
                                    <div class="col-sm-2">
                                        <input id="txtFechaPap" class="form-control" type="text" placeholder="Fecha" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-1" for="txtIMC">
                                        I.M.C.:</label>
                                    <div class="col-sm-2">
                                        <input id="txtIMC" class="form-control" type="text" disabled />
                                    </div>
                                    <div class="col-sm-3">
                                    </div>
                                    <label id="lblEco" class="control-label col-sm-1" for="ddlEco">
                                        Eco Mam.:</label>
                                    <div class="col-sm-2">
                                        <select id="ddlEco" class="form-control">
                                            <option>No</option>
                                            <option>Si</option>
                                        </select>
                                    </div>
                                    <label id="lblEcoFecha" class="control-label col-sm-1" for="txtEcoFecha">
                                        Fecha:</label>
                                    <div class="col-sm-2">
                                        <input id="txtEcoFecha" class="form-control" type="text" placeholder="Fecha" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-1" for="txtCabeza">
                                        Cabeza/ Cuello:</label>
                                    <div class="col-sm-11">
                                        <input id="txtCabeza" class="form-control" type="text" placeholder="Cabeza/ Cuello" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-1" for="txtTorax">
                                        Tórax:</label>
                                    <div class="col-sm-11">
                                        <input id="txtTorax" class="form-control" type="text" placeholder="Tórax" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-1" for="txtPresion">
                                        Abdomen:</label>
                                    <div class="col-sm-11">
                                        <input id="txtAbdomen" class="form-control" type="text" placeholder="Abdomen" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-1" for="txtUrogenital">
                                        Urogenital:</label>
                                    <div class="col-sm-11">
                                        <input id="txtUrogenital" class="form-control" type="text" placeholder="Urogenital" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-1" for="txtSuperior">
                                        Extremidades Sup.:</label>
                                    <div class="col-sm-11">
                                        <input id="txtSuperior" class="form-control" type="text" placeholder="Extremidades Sup." />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-1" for="txtInferior">
                                        Extremidades Inf.:</label>
                                    <div class="col-sm-11">
                                        <input id="txtInferior" class="form-control" type="text" placeholder="Extremidades Inf." />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-1" for="txtColumna">
                                        Columna vertebral:</label>
                                    <div class="col-sm-11">
                                        <input id="txtColumna" class="form-control" type="text" placeholder="Columna vertebral" />
                                    </div>
                                </div>
                            </div>
                            <div id="menu5" class="tab-pane fade">
                                <h3>
                                    Diagnóstico</h3>
                                <div class="form-group">
                                    <label class="control-label col-sm-2" for="txtObservaciones">
                                        Diagnóstico Común:</label>
                                    <div class="col-sm-10">
                                        <textarea id="txtDiagnostico" class="form-control" rows="2" cols="1" placeholder="Diagnóstico Común"></textarea>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-2" for="txtObservaciones">
                                        Diagnóstico Laboral:</label>
                                    <div class="col-sm-10">
                                        <textarea id="txtDiagnosticoLaboral" class="form-control" rows="2" cols="1" placeholder="Diagnóstico Laboral"></textarea>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-2" for="txtObservaciones">
                                        Exámenes Complementarios:</label>
                                    <div class="col-sm-10">
                                        <div class="form-group">
                                            <label class="control-label col-sm-2" for="txtObservaciones">
                                                Imagenología:</label>
                                            <div class="col-sm-8">
                                                <div class="form-group">
                                                    <div class="col-sm-4">
                                                        <label class="checkbox-inline">
                                                            <input id="cbxTorax" type="checkbox" value="" />Rx Tórax</label>
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <label class="checkbox-inline">
                                                            <input id="cbxOsea" type="checkbox" value="" />Rx Ósea</label>
                                                    </div>
                                                    <div class="col-sm-4">
                                                        <label class="checkbox-inline">
                                                            <input id="cbxCavidades" type="checkbox" value="" />Rx Cavidades</label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                                <label class="checkbox-inline">
                                                    <input id="cbxTAC" type="checkbox" value="" />TAC</label>
                                            </div>
                                            <div class="col-sm-2">
                                                <label class="checkbox-inline">
                                                    <input id="cbxRNM" type="checkbox" value="" />RNM</label>
                                            </div>
                                            <div class="col-sm-2">
                                                <label class="checkbox-inline">
                                                    <input id="cbxEEG" type="checkbox" value="" />EEG</label>
                                            </div>
                                            <div class="col-sm-2">
                                                <label class="checkbox-inline">
                                                    <input id="cbxECG" type="checkbox" value="" />ECG</label>
                                            </div>
                                            <div class="col-sm-2">
                                                <label class="checkbox-inline">
                                                    <input id="cbxECARDG" type="checkbox" value="" />ECARDG</label>
                                            </div>
                                            <div class="col-sm-2">
                                                <label class="checkbox-inline">
                                                    <input id="cbxEMG" type="checkbox" value="" />EMG</label>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="control-label col-sm-2" for="txtObservaciones">
                                                Laboratorio:</label>
                                            <div class="col-sm-10">
                                                <textarea id="txtLaboratorio" class="form-control" rows="2" cols="1" placeholder="LABORATORIO"></textarea>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-2" for="txtObservaciones">
                                        Tratamiento:</label>
                                    <div class="col-sm-10">
                                        <textarea id="txtTratamiento" class="form-control" rows="2" cols="1" placeholder="Tratamiento"></textarea>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-2" for="txtObservaciones">
                                        Recomendaciones:</label>
                                    <div class="col-sm-10">
                                        <textarea id="txtRecomendaciones" class="form-control" rows="2" cols="1" placeholder="Recomendaciones"></textarea>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-sm-2" for="txtObservaciones">
                                        Fecha Control:</label>
                                    <div class="col-sm-2">
                                        <input id="txtControlFecha" class="form-control" type="text" placeholder="Fecha" />
                                    </div>
                                    <label class="control-label col-sm-2" for="txtObservaciones">
                                        Hora Control:</label>
                                    <div class="col-sm-2">
                                        <input id="txtControlHora" class="form-control" type="text" placeholder="Hora" />
                                    </div>
                                </div>
                                <button id="btn_Guardar" type="button" class="btn btn-primary" onclick="javascript:GuardarFicha(document.getElementById('txtRut').value, document.getElementById('txtTelefono').value, document.getElementById('txtAntiCargo').value);">
                                    Guardar</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
