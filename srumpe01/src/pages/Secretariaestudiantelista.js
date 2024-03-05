import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { show_alert } from '../functions';
import Swal from 'sweetalert2';
import withReactContent from 'sweetalert2-react-content';
import 'react-datepicker/dist/react-datepicker.css';
 

export default function Secretariaestudiantelista() {
    const url = 'https://localhost:5001/api/candidatoEstudiante';
    const [candidatoEstudiante, setCandidatoEstudiante] = useState([]);
    const [candidatoEstudianteId, setCandidatoEstudianteId] = useState('');
    const [nombre, setNombre] = useState('');
    const [apellido, setApellido] = useState('');
    const [numeroContacto, setNumeroContacto] = useState();
    const [direccion, setDireccion] = useState('');
    const [tipo, setTipo] = useState('');
    const [fechaNacimiento, setFechaNacimiento] = useState(null);
    const [tipoDocumento, settipoDocumento] = useState('');
    const [cargadocumento, setcargadaDocumento] = useState('');
    const [genero, setGenero] = useState('');
    const [operation, setOperation] = useState(1);
    const [title, setTitle] = useState('');


    useEffect(() => {
        getCandidatoEstudiante();
    }, []);

    const getCandidatoEstudiante = async () => {
        const respuesta = await axios.get(url);
        setCandidatoEstudiante(respuesta.data);
    };

    const openModal = (op, candidatoEstudiante) => {
        setOperation(op);
        if (op === 1) {
            setTitle('Registrar Estudiante');
            setCandidatoEstudianteId('');
            setNombre('');
            setApellido('');
            setNumeroContacto('');
            setDireccion('');
            setFechaNacimiento('');
            setTipo('');
            settipoDocumento('');
            setcargadaDocumento(''); 
            setGenero('');
        } else if (op === 2) {
            setTitle('Editar Estudiante');
            setCandidatoEstudianteId(candidatoEstudiante.candidatoEstudianteId);
            setNombre(candidatoEstudiante.nombre);
            setApellido(candidatoEstudiante.apellido);
            setNumeroContacto(candidatoEstudiante.NumeroContacto);
            setDireccion(candidatoEstudiante.direccion);
            setFechaNacimiento(candidatoEstudiante.fechaNacimiento);
            setTipo(candidatoEstudiante.tipo);
            settipoDocumento(candidatoEstudiante.tipoDocumento);
            setcargadaDocumento(candidatoEstudiante.cargadocumento);
            setGenero(candidatoEstudiante.genero);
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
      }else if (numeroContacto === "") {
        show_alert("Escribe el numero de contacto del estudiante", "Escribe el estado del apellido");
      }else if (direccion === "") {
        show_alert("Escribe la direccion del estudiante", "Escribe el estado del apellido");
      }
      else if (fechaNacimiento === null) {
        show_alert("Escribe la fecha de nacimiento del estudiante", "Escribe el estado del apellido");
      } else {
        let parametros;
        let metodo;
  
        if (operation === 1) {
          parametros = { nombre: nombre, apellido: apellido, NumeroContacto: numeroContacto, direccion: direccion, tipo: tipo, fechaNacimiento: fechaNacimiento, tipoDocumento: tipoDocumento, cargadocumento: cargadocumento, genero: genero};
          metodo = "POST";
          
        } else {
          parametros = { nombre: nombre, apellido: apellido, NumeroContacto: numeroContacto, direccion: direccion, tipo: tipo, fechaNacimiento: fechaNacimiento, tipoDocumento: tipoDocumento, cargadocumento: cargadocumento, genero: genero};
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
            title: `¿Seguro quieres eliminar el estudiante ${nombre}?`,
            icon: 'question',
            text: 'Esta acción no se puede deshacer',
            showCancelButton: true,
            confirmButtonText: 'Sí, eliminar',
            cancelButtonText: 'Cancelar',
        }).then(async (result) => {
            if (result.isConfirmed) {
                try {
                    await axios.delete(`${url}/${candidatoEstudianteId}`);
                    show_alert('Estudiante eliminado exitosamente', 'success');
                    getCandidatoEstudiante();
                } catch (error) {
                    show_alert('Error al eliminar al estudiante', 'error');
                    console.error(error);
                }} else {
                show_alert('El estudiante no fue eliminado', 'info');
            }
        });
    };

    return(
        
            <React.Fragment>
            <div className="App">
	<main className="full-box main-container">
		
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
									<a href="/Secretariadocentebuscar"><i className="fas fa-search fa-fw"></i> &nbsp; Buscar Docentes</a>
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


		
		<section className="full-box page-content">
			<nav className="full-box navbar-info">
				<a href="#" className="float-left show-nav-lateral">
					<i className="fas fa-exchange-alt"></i>
				</a>
				<a href="user-update.html">
					<i className="fas fa-user-cog"></i>
				</a>
				<a href="#" className="btn-exit-system">
					<i className="fas fa-power-off"></i>
				</a>
			</nav>

			
			<div className="full-box page-header">
				<h3 className="text-left">
					<i className="fas fa-clipboard-list fa-fw"></i> &nbsp; LISTA DE ESTUDIANTES
				</h3>
				<p className="text-justify">
					
				</p>
			</div>

			<div className="container-fluid">
				<ul className="full-box list-unstyled page-nav-tabs">
					<li
         >
          <div>
          <a  onClick={() => openModal(1)}
          className=""
          data-toggle="modal"
          data-target="#ModalCandidatoEstudiante" ><i className="fas fa-plus fa-fw"></i> Añadir Estudiante nuevo</a>
          </div>
          </li>
					<li>
						<a className="active" href="/Secretariaestudiantelista"><i className="fas fa-clipboard-list fa-fw"></i> &nbsp; LISTA DE ESTUDIANTES</a>
					</li>
					<li>
						<a style={{color: 'black'}} href="/Secretariabuscarestudiante"><i className="fas fa-search fa-fw"></i> &nbsp; BUSCAR ESTUDIANTE</a>
					</li>
				</ul> 
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
								<th>NUMERO CONTACTO</th>
								<th>DIRECCION</th>
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
								<td>{CandidatoEstudiante.NumeroContacto}</td>
								<td>{CandidatoEstudiante.direccion}</td>
								<td>
								<button onClick={() => openModal(2, CandidatoEstudiante)} className="btn btn-success" data-toggle='modal' data-target='#ModalCandidatoEstudiante'>
                          <i className="fas fa-edit"></i>
                        </button>
									/&nbsp;
									<button onClick={() => deleteCandidatoEstudiante(CandidatoEstudiante.candidatoEstudianteId, CandidatoEstudiante.nombre, CandidatoEstudiante.apellido)} className="btn btn-danger">
                  <i className="far fa-trash-alt"></i>
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
				<div id="ModalCandidatoEstudiante" className="modal fade " aria-hidden="true">
        <div className="modal-dialog">
          <div className="modal-content">
            <div className="modal-header">
              <label className="h5">{title}</label>
              <button type="button" className="fas fa-times" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div className="modal-body">
              <input type="hidden" id="candidatoEstudianteId" />
              <div className="input-group mb-3">
                
                
              </div>
                    <div className="input-group mb-3">
                    <span className="input-group-text"><i className="fas fa-signature"></i></span>
                    <input
                        type="text"
                        id="Nombre"
                        className="form-control"
                        placeholder="NOMBRE"
                        value={nombre}
                        onChange={(e) => setNombre(e.target.value)}
                      />
                    </div>
                    <div className="input-group mb-3">
                      <span className="input-group-text"><i className="fas fa-signature"></i></span>
                      <input
                        type="text"
                        id="Apellido"
                        className="form-control"
                        placeholder="APELLIDO"
                        value={apellido}
                        onChange={(e) => setApellido(e.target.value)}
                      />
                    </div>
                    <div className="input-group mb-3">
                      <span className="input-group-text"><i className="fas fa-phone-alt"></i></span>
                      <input
                        type="text"
                        id="NumeroContacto"
                        className="form-control"
                        placeholder="Numero Contacto"
                        value={numeroContacto}
                        onChange={(e) => setNumeroContacto(e.target.value)}
                      />
                    </div>
                    <div className="input-group mb-3">
                      <span className="input-group-text"><i className="fas fa-map-marker-alt"></i></span>
                      <input
                        type="text"
                        id="Direccion"
                        className="form-control"
                        placeholder="DIRECCION"
                        value={direccion}
                        onChange={(e) => setDireccion(e.target.value)}
                      />
                    </div>
                    <input type="hidden" id="candidatoEstudianteId" />
                        <div className="input-group mb-3">
                            <select className="form-select" value={tipo} onChange={(e) => setTipo(e.target.value)}>
                                <option value="">Seleccione tipo de rol</option>
                                <option value="Estudiante">Estudiante</option>
                                <option value="Docente">Docente</option>
                            </select>
                        </div>
                        <div className="input-group mb-3">
                            <div class="form-group">
                              <span className="input-group-text"><i className="far fa-calendar-alt center"></i>Selecciona una fecha: </span>
                            
                            
                            <input type="datetime-local" id="fecha" name="fecha" class="form-control" value={fechaNacimiento} onChange={(e)=>setFechaNacimiento(e.target.value)}/>
                          </div>
                        </div>
                        <div className="input-group mb-3">
                          <span > <i class="fas fa-venus-mars"></i> Genero</span>
                            <select className="form-select" value={genero} onChange={(e) => setGenero(e.target.value)}>
                                <option value="">Seleccione Genero</option>
                                <option value="Maculino">Masculino</option>
                                <option value="Femenino">Femenino</option>
                                <option value="Otro">Otro</option>
                            </select>
                        </div>
                        <div className="input-group mb-3">
                        <span ><i class="fas fa-id-card"></i> Tipo Documento</span>
                            <select className="form-select" value={tipoDocumento} onChange={(e) => settipoDocumento(e.target.value)}>
                                <option value="">Seleccione Tipo Documento</option>
                                <option value="cedula">C.C</option>
                                <option value="Targeta de Identidad">T.I</option>
                                <option value="otro">Otro</option>
                            </select>
                        </div>
                        <div class="mb-3">
                        <label for="formFileSm" class="form-label">Inserte el Documento</label>
                        <input class="form-control form-control-sm" id="formFileSm" type="file"/>
                        <input
                        type="text"
                        id="cargadaDocumento"
                        className="form-control"
                        placeholder="Inserto documento (SI O NO)"
                        value={cargadocumento}
                        onChange={(e) => setcargadaDocumento(e.target.value)}
                      />
</div>
                        
                    </div>
                    <div className='modal-footer'>
                    <div className='d-grid '>
                    <div className="d-flex justify-content-center  ">
                      <button onClick={() => validar()} class="btn btn-outline-success">Guardar</button>
                    </div>
                    </div>
                  
                  
                  <div className="d-flex justify-content-center ">
                    <button type='button' id="btnCerrar" className='btn btn-secondary' data-bs-dismiss='modal'>Cerrar</button>
                  </div>
                  </div>
                </div>
              </div>
            

		</div>
    
    </div>
    
	</React.Fragment>
	
          
	
	
            
        
    )
}