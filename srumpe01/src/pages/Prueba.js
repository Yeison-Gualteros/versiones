import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { show_alert } from '../functions';
import Swal from 'sweetalert2';
import withReactContent from 'sweetalert2-react-content';
import { Modal } from 'bootstrap'; // Importa bootstrap

export default function Secretariaestudiantelista() {
    const url = 'https://localhost:7284/api/candidatoEstudiante';
    const [candidatoEstudiante, setCandidatoEstudiante] = useState([]);
    const [candidatoEstudianteId, setCandidatoEstudianteId] = useState('');
    const [nombre, setNombre] = useState('');
    const [apellido, setApellido] = useState('');
    const [telefono, setTelefono] = useState('');
    const [direccion, setDireccion] = useState('');
    const [operation, setOperation] = useState(1);
    const [title, setTitle] = useState('');
    const [modalVisible, setModalVisible] = useState(false);


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
            setTelefono('');
            setDireccion('');
        } else if (op === 2) {
            setTitle('Editar Estudiante');
            setCandidatoEstudianteId(candidatoEstudiante.candidatoEstudianteId);
            setNombre(candidatoEstudiante.nombre);
            setApellido(candidatoEstudiante.apellido);
            setTelefono(candidatoEstudiante.telefono);
            setDireccion(candidatoEstudiante.direccion);
        }
        setModalVisible(true);
        window.setTimeout(function () {
            document.getElementById('Nombre').focus();
        }, 500);
    };

    const validar = () => {
        if (nombre.trim() === '') {
            show_alert('Escribe el nombre del estudiante', 'Escribe el nombre del nombre');
        } else if (apellido.trim() === '') {
            show_alert('Escribe el apellido del estudiante', 'Escribe el apellido');
        } else if (telefono.trim() === '') {
            show_alert('Escribe el teléfono del estudiante', 'Escribe el teléfono');
        } else if (direccion.trim() === '') {
            show_alert('Escribe la dirección del estudiante', 'Escribe la dirección');
        } else {
            const parametros = { nombre, apellido, telefono, direccion };
            const metodo = operation === 1 ? 'POST' : 'PUT';
            enviarSolicitud(metodo, parametros);
        }
        setModalVisible(false);
    };

    const enviarSolicitud = async (metodo, parametros) => {
      try {
          const response = await axios[metodo.toLowerCase()](`${url}/${candidatoEstudianteId || ''}`, parametros);
          if (response.status === 200) {
              show_alert(`${operation === 1 ? 'Estudiante añadido' : 'Estudiante actualizado'} exitosamente`, 'success');
              // Cerrar el modal después de mostrar el mensaje
              const myModal = new Modal.Modal(document.getElementById('ModalCandidatoEstudiante'));
              myModal.hide();
              // Limpiar los campos del formulario
              setNombre('');
              setApellido('');
              setTelefono('');
              setDireccion('');
              // Actualizar la lista de estudiantes
              getCandidatoEstudiante();
              setModalVisible(false);
          }
      } catch (error) {
          show_alert('Error en la solicitud', 'error');
          console.error(error);
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
                }
            } else {
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
					{/*<li onClick={() => openModal(1)}
					className="btn btn-primary"
					data-toggle="modal"
					data-target="#ModalCandidatoEstudiante">
						<a href="estudiante-nuevo.html"><i className="fas fa-plus fa-fw"></i> &nbsp; AGREGAR ESTUDIANTE</a>
					</li>*/}
					<li>
						<a className="active" href="/Secretariaestudiantelista"><i className="fas fa-clipboard-list fa-fw"></i> &nbsp; LISTA DE ESTUDIANTES</a>
					</li>
					<li>
						<a href="/Secretariabuscarestudiante"><i className="fas fa-search fa-fw"></i> &nbsp; BUSCAR ESTUDIANTE</a>
					</li>
				</ul> 
			</div>
      
			<div className="container-fluid">
                            <div className="row mt-3">
                                <div className="col-md-4 offset-4">
                                    <div className="d-gris mx-auto">
                                        <div className="d-flex justify-content-center align-items-center h-100">
                                        <button
                                            onClick={() => openModal(1)}
                                            className="btn btn-primary"
                                            data-toggle="modal"
                                            data-target="#ModalCandidatoEstudiante" // Corregido el target
                                        >
                                            <i className="fa-solid fa-circle-plus"></i> Añadir Estudiante nuevo
                                        </button>

                                        </div>
                                    </div>
                                </div>
                            </div>
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
								<button onClick={() => openModal(2, CandidatoEstudiante)} className="btn btn-warning" data-toggle='modal' data-target='#ModalCandidatoEstudiante'>
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
				<div id="ModalCandidatoEstudiante" className="modal fade" aria-hidden="true">
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
                        id="Telefono"
                        className="form-control"
                        placeholder="TELEFONO"
                        value={telefono}
                        onChange={(e) => setTelefono(e.target.value)}
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
                    <div className='d-grid col-6 mx-auto'>
                    <div className="d-flex justify-content-center align-items-center h-100">
                      <button onClick={() => validar()} class="btn btn-outline-success">Guardar</button>
                    </div>
                    </div>
                  </div>
                  <div className='modal-footer'>
                  <div className="d-flex justify-content-center align-items-center h-100">
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