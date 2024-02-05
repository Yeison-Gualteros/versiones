import React, { useEffect, useState } from 'react';
import { Link } from "react-router-dom";
import axios from 'axios';
import { show_alert } from '../functions';
import Swal from 'sweetalert2';
import withReactContent from 'sweetalert2-react-content';

export default function Secretariabuscarestudiante() {

    const url = 'https://localhost:5001/api/candidatoEstudiante';
  const [candidatoEstudiante, setCandidatoEstudiante] = useState([]);
  const [candidatoEstudianteId, setCandidatoEstudianteId] = useState('');
  const [nombre, setNombre] = useState('');
  const [apellido, setApellido] = useState('');
  const [telefono, setTelefono] = useState('');
  const [direccion, setDireccion] = useState('');
  const [operation, setOperations] = useState(1);
  const [title, setTitle] = useState('');


  useEffect(() => {
	getCandidatoEstudiante();
  },[]);

  const getCandidatoEstudiante = async () => {
	const respuesta = await axios.get(url);
	setCandidatoEstudiante(respuesta.data);
  };

  const openModal = (op, candidatoEstudiante) => {
    setOperations(op);
    if (op === 1) {
      setTitle('Registrar Estudiante');
      setCandidatoEstudianteId('');
      setNombre('');
      setApellido('');
    } else if (op === 2) {
      setTitle('Editar Estudiante');
      setCandidatoEstudianteId(candidatoEstudiante.candidatoEstudianteId);
      setNombre(candidatoEstudiante.nombre);
      setApellido(candidatoEstudiante.apellido);
    }
    window.setTimeout(function () {
      document.getElementById('Nombre').focus();
    }, 500);
  };

  const validar = () => {
    if (nombre.trim() === "") {
      show_alert("Escribe el nombre del estudiante", "Escribe el nombre del nombre");
    } else if (apellido === "") {
      show_alert("Escribe el apellido del estudiante", "Escribe el estado del apellido");
    } else {
      let parametros;
      let metodo;

      if (operation === 1) {
        parametros = { nombre: nombre, apellido: apellido };
        metodo = "POST";
        
      } else {
        parametros = { nombre: nombre, apellido: apellido };
        metodo = "PUT";
      }

      enviarSolicitud(metodo, parametros);
    }
  };

  const enviarSolicitud = async (metodo, parametros) => {
    if (metodo === "POST") {
      axios
        .post(`${url}`, parametros)
        .then(function (respuesta) {
          show_alert("Estudiante añadido exitosamente", "success");
          document.getElementById("btnCerrar").click();
          getCandidatoEstudiante();
        })
        .catch(function (error) {
          show_alert("error", "Error de solucitud");
          console.log(error);
        });
    } else if (metodo === "PUT") {
      axios
        .put(`${url}/${candidatoEstudianteId}`, parametros)
        .then(function (respuesta) {
          console.log("Solicitud PUT exitosa:", respuesta.data);
          var tipo = respuesta.data[0];
          var msj = respuesta.data[1];
          show_alert("Cargo editado con éxito", "success");
          document.getElementById("btnCerrar").click();
          getCandidatoEstudiante();
        })
        .catch(function (error) {
          show_alert("Error de solucitud", "error");
          console.log(error);
        });
    }
  };


  const deleteCandidatoEstudiante = (candidatoEstudianteId, nombre) => {
    const MySwal = withReactContent(Swal);
    MySwal.fire({
      title: "¿Seguro quieres eliminar el cargo " + nombre + "?",
      icon: "question",
      text: "No se podra dar marcha atras",
      showCancelButton: true,
      confirmButtonText: "Si, eliminar",
      cancelButtonText: "Cancelar",
    }).then(async (result) => {
      if (result.isConfirmed) {
        try {
          await axios.delete(`${url}/${candidatoEstudianteId}`);
          show_alert("Usuario eliminado exitosamente", "success");
          getCandidatoEstudiante();
        } catch (error) {
          show_alert("Error al eliminar al estudiante", "error");
          console.error(error);
        }
      } else {
        show_alert("El estudiante no fue eliminado", "info");
      }
    });
  };
    
    return(
        
            <React.Fragment>
            
	
	
	<main class="full-box main-container">
		
	<section className="full-box nav-lateral">
			<div className="full-box nav-lateral-bg show-nav-lateral"></div>
			<div className="full-box nav-lateral-content">
				<figure className="full-box nav-lateral-avatar">
					<i className="far fa-times-circle show-nav-lateral"></i>
					<figcaption className="SRMNPE text-center">
						SRUNPE <br/><small className="roboto-condensed-light"></small>
					</figcaption>
					<img src="/assets/avatar/Avatar_negro.jpg" className="img-fluid" alt="Avatar"/>
					<figcaption className="roboto-medium text-center">
                    Axl Julian Acuña Rubiano <br/><small className="roboto-condensed-light"><p><span className="badge badge-info">Administrativo</span></p></small>
					</figcaption>
				</figure>
				<div className="full-box nav-lateral-bar"></div>
				<nav className="full-box nav-lateral-menu">
					<ul>
						<li>
							<a href="/Secretaria"><i className="fab fa-dashcube fa-fw"></i> &nbsp; Inicio</a>
						</li>

						<li>
							<a href="#" className="nav-btn-submenu"><i className="fas fa-users fa-fw"></i> &nbsp;  Estudiantes <i className="fas fa-chevron-down"></i></a>
							<ul>
								
								<li>
									<a href="/Secretariaestudiantelista"><i className="fas fa-clipboard-list fa-fw"></i> &nbsp; Lista De Estudiante</a>
								</li>
								<li>
									<a href="/Secretariabuscarestudiante"><i className="fas fa-search fa-fw"></i> &nbsp; Buscar Estudiante</a>
								</li>
							</ul>
						</li>

						<li>
							<a href="#" className="nav-btn-submenu"><i className="fas fa-chalkboard-user fa-fw"></i> &nbsp; Docentes <i className="fas fa-chevron-down"></i></a>
							<ul>
								{/*<li>
									<a href="nuevo-profesor.html"><i className="fas fa-plus fa-fw"></i> &nbsp; Agregar Docentes</a>
	</li>*/}
								<li>
									<a href="/Secretariadocentelista"><i className="fas fa-clipboard-list fa-fw"></i> &nbsp; Lista De Docentes</a>
								</li>
								<li>
									<a href="/Secrtariadocentebuscar"><i className="fas fa-search fa-fw"></i> &nbsp; Buscar Docentes</a>
								</li>
							</ul>
						</li>

						<li>
							<a href="#" className="nav-btn-submenu"><i className="fas fa-layer-group fa-fw"></i> &nbsp; Cursos <i className="fas fa-chevron-down"></i></a>
							<ul>
								{/*<li>
									<a href="curso-nuevo.html"><i className="fas fa-plus fa-fw"></i> &nbsp; Agregar Curso</a>
								</li>*/}
								<li>
									<a href="/Secretariacursoslista"><i className="fas fa-clipboard-list fa-fw"></i> &nbsp; Lista De Cursos</a>
								</li>
								<li>
									<a href="/Secretariacursobuscar"><i className="fas fa-search fa-fw"></i> &nbsp; Buscar Curso</a>
								</li>
							</ul>
						</li>
						<li>
							<a href="#" className="nav-btn-submenu"><i className="fas fa-pallet fa-fw"></i> &nbsp; Materias <i className="fas fa-chevron-down"></i></a>
							<ul>
								{/*<li>
									<a href="materia-nueva.html"><i className="fas fa-plus fa-fw"></i> &nbsp; Agregar Materias</a>
								</li>*/}
								<li>
									<a href="/Secretariamaterialista"><i className="fas fa-clipboard-list fa-fw"></i> &nbsp; Lista De Materias</a>
								</li>
								
							</ul>
						</li>

						

						<li>
							<a href="/Secretariareclamos"><i className="fas fa-exclamation-circle fa-fw"></i> &nbsp; Reclamos</a>
						</li>
					</ul>
				</nav>
			</div>
		</section>

		
		<section class="full-box page-content">
			<nav class="full-box navbar-info">
				<a href="#" class="float-left show-nav-lateral">
					<i class="fas fa-exchange-alt"></i>
				</a>
				<a href="/Secretariauserupdate.html">
					<i class="fas fa-user-cog"></i>
				</a>
				<a href="#" class="btn-exit-system">
					<i class="fas fa-power-off"></i>
				</a>
			</nav>

			
			
			<div class="full-box page-header">
				<h3 class="text-left">
					<i class="fas fa-search fa-fw"></i> &nbsp; BUSCAR ESTUDIANTE
				</h3>
				<p class="text-justify">
					
				</p>
			</div>

			<div class="container-fluid">
				<ul class="full-box list-unstyled page-nav-tabs">
					{/*<li>
						<a href="estudiante-nuevo.html"><i class="fas fa-plus fa-fw"></i> &nbsp; AGREGAR ESTUDIANTE</a>
					</li>*/}
					<li>
						<a href="/Secretariaestudiantelista"><i class="fas fa-clipboard-list fa-fw"></i> &nbsp; LISTA DE ESTUDIANTES</a>
					</li>
					<li>
						<a class="active" href="/Secretariabuscarestudiante"><i class="fas fa-search fa-fw"></i> &nbsp; BUSCAR ESTUDIANTE</a>
					</li>
				</ul>	
			</div>
			
			
			<div class="container-fluid">
				<form class="form-neon" action="">
					<div class="container-fluid">
						<div class="row justify-content-md-center">
							<div class="col-12 col-md-6">
								<div class="form-group">
									<label for="inputSearch" class="frome bmd-label-floating">¿Qué estudiante estas buscando?</label>
									<input type="text" class="form-control" name="busqueda-" id="inputSearch" maxlength="30"/>
								</div>
							</div>
							<div class="col-12">
								<p class="text-center" style={{marginTop: "40px;"}}>
									<button type="submit" class="btn btn-raised btn-info"><i class="fas fa-search"></i> &nbsp; BUSCAR</button>
								</p>
							</div>
						</div>
					</div>
				</form>
			</div>

			
			<div class="container-fluid">
				<form action="">
					<input type="hidden" name="eliminar-busqueda" value="eliminar"/>
					<div class="container-fluid">
						<div class="row justify-content-md-center">
							<div class="col-12 col-md-6">
								<p class="text-center" style={{fontSize: "20px;"}}>
									Resultados de la busqueda <strong>“Buscar”</strong>
								</p>
							</div>
							<div class="col-12">
								<p class="text-center" style={{marginTop: "20px;"}}>
									<button type="submit" class="btn btn-raised btn-danger"><i class="far fa-trash-alt"></i> &nbsp; ELIMINAR BÚSQUEDA</button>
								</p>
							</div>
						</div>
					</div>
				</form>
			</div>


			<div className="container-fluid">
				<div className="table-responsive">
					
					<table className="table table-dark table-sm">
						<thead>
							<tr className="text-center roboto-medium">
								<th>#</th>
								<th>ID</th>
								<th>NOMBRE</th>
								<th>APELLIDO</th>
								<th>DIRECCION</th>
								<th>TELEFONO</th>
								<th>ACTUALIZAR/ELIMINAR</th>
								
							</tr>
						</thead>
						<tbody className="table-group-divider">
							{candidatoEstudiante.map((CandidatoEstudiante, i) =>( 
							<tr className="text-center"  key={CandidatoEstudiante.candidatoEstudianteId}>
								<td>{i+1}</td>
								<td>{CandidatoEstudiante.candidatoEstudianteId}</td>
								<td>{CandidatoEstudiante.nombre}</td>
								<td>{CandidatoEstudiante.apellido}</td>
								<td>{CandidatoEstudiante.direccion}</td>
								<td>{CandidatoEstudiante.telefono}</td>
								<td>
								<button onClick={() => openModal(2, CandidatoEstudiante)} className="btn btn-warning" data-bs-toggle='modal' data-bs-target='#modalCandidatoEstudiante'>
                          <i className="fa-solid fa-edit"></i>
                        </button>
									&nbsp;
									<button onClick={() => deleteCandidatoEstudiante(CandidatoEstudiante.candidatoEstudianteId, CandidatoEstudiante.nombre, CandidatoEstudiante.apellido)} className="btn btn-danger">
                          <i className="fa-solid fa-trash"></i>
                        </button>


								</td>
								
							</tr>
							))}
							
							
						</tbody>
					</table>
				</div>
				</div>

		</section>
	</main>
	
	
	
            </React.Fragment>
        
    )
}