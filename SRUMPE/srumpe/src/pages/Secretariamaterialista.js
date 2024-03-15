import  React, { useEffect, useState } from 'react';
import axios from 'axios';
import { show_alert } from '../functions';
import Swal from 'sweetalert2';
import withReactContent from 'sweetalert2-react-content';

export default function Secretariamaterialista() {


	const url = 'https://localhost:7284/api/materia';
	const [materia, setMateria] = useState([]);
	const [materiaId, setMateriaId] = useState('');
	const [nombre, setNombre] = useState('');
	const [descripcion, setDescripcion] = useState('');
	const [departamentoacademico, setDepartamentamentament] = useState('');
	const [profesorasignado, setProfesorasignado] = useState('');
	const [modalidadensenanza, setModalidadensenanza] = useState('');
	const [notasadicionales, setNotasadicionales] = useState('');
	const [nivel, setNivel] = useState('');
	const [estado, setEstado] = useState('');
	const [gruposeccionmateria, setgruposeccionmateria] = useState('');
	const [metodosensenanza, setmetodosensenanza] = useState('');
	const [operation, setOperation] = useState(1);
    const [title, setTitle] = useState('');
	const [showModal, setShowModal] = useState(false); // Estado para controlar la visibilidad del modal


	const url2 = 'https://localhost:7284/api/Docente'
    const [Docente, setDocente] = useState([]);
    const [DocenteId, setDocenteId] = useState('');

	useEffect(() => {
        getmateria();
    }, []);

	useEffect(() => {
		fetch(url2)
		.then(response => response.json())
		.then((data) => setDocente(data))
		.catch((error) => console.error('Error fetching cursos:', error))
	}, [url2]);

	const getmateria = async () => {
		try {
			const respuesta = await axios.get(url);
			// Asegurarse de que respuesta.data sea un array
			if (Array.isArray(respuesta.data)) {
				setMateria(respuesta.data);
			} else {
				// Si no es un array, muestra un mensaje de error o realiza otra acción adecuada
				console.error('La respuesta no es un array:', respuesta.data);
			}
		} catch (error) {
			console.error('Error al obtener datos de materia:', error);
		}
	};


	const openModal = (op, materia)=>{
		setOperation(op);
        if (op === 1) {
            setTitle('Registrar Materia');
            setMateriaId('');
            setNombre('');
            setDescripcion('');
            setDepartamentamentament('');
            setProfesorasignado('');
            setModalidadensenanza('');
            setNotasadicionales('');
            setmetodosensenanza('');
			setNivel('');
			setEstado('');
			setgruposeccionmateria('');
        }
		if (op === 2) {

			setTitle('Editar Materia');
            setMateriaId(materia.materiaId);
            setNombre(materia.nombre);
            setDescripcion(materia.descripcion);
            setDepartamentamentament(materia.departamentoacademico);
            setProfesorasignado(materia.profesorasignado);
            setModalidadensenanza(materia.modalidadensenanza); 
            setNotasadicionales(materia.notasadicionales);
            setmetodosensenanza(materia.metodosensenanza);
			setNivel(materia.nivel);
			setEstado(materia.estado);
			setgruposeccionmateria(materia.gruposeccionmateria);
			setMateriaId(materia.materiaId);
		}
		window.setTimeout(function(){
			document.getElementById('Nombre').focus();
		}, 500);
		setShowModal(true);
	};

	const validar = (function(){
		if (nombre && nombre.trim() === "") {
			show_alert('Escribe el nombre de la materia nueva', 'error');
		}
		else if (descripcion.trim() === "") {
            show_alert('Escribe la descripción de la materia nueva', 'error');
        }
		else if (departamentoacademico.trim() === "") {
            show_alert('Escribe el departamento academico de la materia nueva', 'error');
        }
		else if (profesorasignado.trim() === '') {
            show_alert('Escribe el profesor asignado de la materia nueva', 'error');
        }
		else if (modalidadensenanza.trim() === "") {
            show_alert('Escribe la modalidad de la materia nueva', 'error');
        }
		else if (notasadicionales.trim() === "") {
            show_alert('Escribe las notas adicionales de la materia nueva', 'error');
        }
		else if (metodosensenanza.trim() === "") {
            show_alert('Escribe el metodo de la materia nueva', 'error');
        }

		else {
			let parametros;
			let metodo;
			if (operation === 1) {
				parametros = { 
					nombre: nombre, 
					descripcion: descripcion, 
					departamentoacademico: departamentoacademico, 
					profesorasignado: profesorasignado, 
					modalidadensenanza: modalidadensenanza, 
					notasadicionales: notasadicionales, 
					metodosensenanza: metodosensenanza, 
					nivel: nivel, 
					estado: estado, 
                    gruposeccionmateria: gruposeccionmateria,
					materiaId:[materiaId]
				};
                metodo = "POST";
				cerrarModal();
			}
			else {
				parametros = { materiaId: [materiaId], 
					nombre: nombre, 
					descripcion: descripcion, 
					departamentoacademico: departamentoacademico, 
					profesorasignado: profesorasignado, 
					modalidadensenanza: modalidadensenanza, 
					notasadicionales: notasadicionales, 
					metodosensenanza: metodosensenanza,
					nivel: nivel, 
                    estado: estado, 
                    gruposeccionmateria: gruposeccionmateria	
				};
                metodo = "PUT";
				cerrarModal();
			}
			enviarSolicitud(metodo, parametros);
			
		}

	})
	const cerrarModal = () => {
		const modal = document.getElementById('modalmateria');
		modal.classList.remove('show'); // Eliminar la clase 'show' para ocultar el modal
		modal.setAttribute('aria-hidden', 'true'); // Asegurarse de que el modal esté marcado como oculto para accesibilidad
		document.body.classList.remove('modal-open'); // Eliminar la clase 'modal-open' del body para permitir el scroll nuevamente
		const modalBackdrop = document.querySelector('.modal-backdrop'); // Eliminar el backdrop del modal si existe
		if (modalBackdrop) {
			document.body.removeChild(modalBackdrop);
		}
		setShowModal(false);
	};

	const enviarSolicitud = async (metodo, parametros) => {
		if (metodo === "POST") {
			await axios.post(url, parametros);
			show_alert('Materia Registrada', 'La materia ha sido registrada correctamente');
		}
		if (metodo === "PUT") {
			await axios.put(url + '/' + materiaId, parametros);
			show_alert('Materia Editada', 'La materia ha sido editada correctamente');
		}
		// Obtener nuevamente los datos de todas las materias después de la operación
		getmateria();
	};

	const deletemateria = (materiaId, nombre) => {
		const MySwal = withReactContent(Swal);
		MySwal.fire({
			title: '¿Estás seguro?',
            text: "¡No podrás revertir esto!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Si, eliminar!',
			cancelButtonText: 'Cancelar'
		}).then(async (result) => {
			if (result.isConfirmed) {
				try {
					await axios.delete(`${url}/${materiaId}`);
					show_alert("Materia eliminada exitosamente", "success");
					getmateria();
				}catch (error){
					show_alert("No se pudo eliminar la materia", "error");
					console.error(error)
				}
			}else {
				show_alert("La materia no fue elimina", "info")
			}
		})
	}
    return(
        
            <React.Fragment>
            
	
	
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

						

						{/*<li>
							<a href="/Secretariareclamos"><i className="fas fa-exclamation-circle fa-fw"></i> &nbsp; Reclamos</a>
							</li>*/}
					</ul>
				</nav>
			</div>
		</section>

		
		<section className="full-box page-content">
			<nav className="full-box navbar-info">
				<a href="#" className="float-left show-nav-lateral">
					<i className="fas fa-exchange-alt"></i>
				</a>
				<a href="/Secretariaactualizar">
					<i className="fas fa-user-cog"></i>
				</a>
				<a href="#" className="btn-exit-system">
					<i className="fas fa-power-off"></i>
				</a>
			</nav>
            
			<div className="full-box page-header">
				<h3 className="text-left">
					<i className="fas fa-clipboard-list fa-fw"></i> &nbsp; LISTA DE MATERIAS
				</h3>
				<p className="text-justify">
					
				</p>
			</div>

			<div className="container-fluid">
				<ul className="full-box list-unstyled page-nav-tabs">
					<li>                
						<div
							onClick={() => openModal(1)}
							data-toggle="modal"
							data-target="#modalmateria" // Corregido el target
						><a ><i className="fas fa-plus fa-fw"></i> 
								Añadir Materia Nueva
								</a>
						</div>
					</li>
					<li>
						<a className="active" href="materia-lista.html"><i className="fas fa-clipboard-list fa-fw"></i> &nbsp; LISTA DE MATERIAS</a>
					</li>
					
				</ul>	
			</div>
			
			
			<div className="container-fluid">
    <div className="table-responsive">
        <table className="table table-dark table-sm">
            <thead>
                <tr className="text-center roboto-medium">
                    <th>#</th>                                
                    <th>MATERIAS</th>
                    <th>DOCENTES</th>
                    <th>ACTUALIZAR / ELIMINAR</th>
                </tr>
            </thead>
            <tbody>
                {Array.isArray(materia) && materia.length > 0 && materia.map((materia, i) => (
                    <tr key={i} className="text-center">
                        <td>{i + 1}</td>
                        <td>{materia.nombre}</td>
                        <td>{Docente.find(docente => docente.DocenteId === materia.profesorasignado)?.nombres}</td>
                        <td>
                            <button onClick={() => openModal(2, materia)} className="btn btn-success" data-toggle='modal' data-target='#modalmateria'>
                                <i className="fas fa-edit"></i>
                            </button>
                            / &nbsp;
                            <button onClick={() => deletemateria(materia.materiaId, materia.nombre, materia.descripcion, materia.departamentoacademico, materia.profesorasignado, materia.modalidadensenanza, materia.notasadicionales, materia.metodosensenanza)} className="btn btn-danger">
                                <i className="far fa-trash-alt"></i>
                            </button>
                        </td>
                    </tr>
                ))}
            </tbody>
        </table>
    </div>
    <nav aria-label="Page navigation example">
        <ul className="pagination justify-content-center">
            <li className="page-item disabled">
                <a className="page-link" href="#" tabIndex="-1">Anterior</a>
            </li>
            <li className="page-item"><a className="page-link" href="#">1</a></li>
            <li className="page-item"><a className="page-link" href="#">2</a></li>
            <li className="page-item"><a className="page-link" href="#">3</a></li>
            <li className="page-item">
                <a className="page-link" href="#">Siguiente</a>
            </li>
        </ul>
    </nav>
</div>


		</section>
	</main>
	<div id="modalmateria" className="modal fade" aria-hidden="true">
        <div className="modal-dialog">
          <div className="modal-content">
            <div className="modal-header">
              <label className="h5">{title}</label>
              <button type="button" className="fas fa-times-circle" aria-label="Close" onClick={cerrarModal}></button>
            </div>
            <div className="modal-body">
              <input type="hidden" id="materia" />
              <div className="input-group mb-3">
                
                
              </div>
                    <div className="input-group mb-3">
                    <span className="input-group-text"><i className="fas fa-book-open"></i></span>
                    <input
                        type="text"
                        id="Nombre"
                        className="form-control"
                        placeholder="Nombre de la materia"
                        value={nombre} 
                        onChange={(e) => setNombre(e.target.value)}
                      />
                    </div>
					<div className="input-group mb-3">
                    <span className="input-group-text"><i className="far fa-newspaper"></i></span>
                    <input
                        type="text"
                        id="materiadescripcion"
                        className="form-control"
                        placeholder="Descripcion del curso"
                        value={descripcion} 
                        onChange={(e) => setDescripcion(e.target.value)}
                      />
                    </div>
					<div className="input-group mb-3">
                    <span className="input-group-text"><i className="fas fa-school"></i></span>
                    <input
                        type="text"
                        id="departementoacademico"
                        className="form-control"
                        placeholder="Departamento Academico"
                        value={departamentoacademico} 
                        onChange={(e) => setDepartamentamentament(e.target.value)}
                      />
                    </div>
					<div className="input-group mb-3">
                      <span className="input-group-text"><i className="fas fa-chalkboard-teacher"></i></span>
                      <select
						className="form-control"
						name="item_estado"
						id="item_estado"
						value={profesorasignado}
						onChange={(e) => setProfesorasignado(e.target.value)}
					>
						<option value="" disabled>
							Seleccione el Docente
						</option>
						{Docente.length > 0 ? (
							Docente.map((docente) => (
								<option key={docente.DocenteId} value={docente.DocenteId}>
									{docente.nombres}
								</option>
							))
						) : (
							<option value="" disabled>
								Cargando Docentes...
							</option>
						)}
					</select>

		  
                    </div>
					<div className="input-group mb-3">
                          <span > <i className="fas fa-level-up-alt"></i> Nivel</span>
                            <select className="form-select" value={nivel} onChange={(e) => setNivel(e.target.value)}>
                                <option value="">Seleccione Nivel</option>
                                <option value="Intermedio">Intermedio</option>
                                <option value="Avanzado">Avanzado</option>
                                <option value="Otro">Otro</option>
                            </select>
                        </div>
						<div className="input-group mb-3">
                          <span className="input-group-text"> <i className="fas fa-laptop-code"></i> Modalidad de Enseñanza</span>
						  <input
							type="text"
							id="codigo"
							className="form-control"
							placeholder="Metodos de enseñanza..."
							value={modalidadensenanza}  
							onChange={(e) => setModalidadensenanza(e.target.value)}
						/>
                        </div>
						<div className="input-group mb-3">
                          <span > <i className="fas fa-stream"></i> Estado</span>
                            <select className="form-select" value={estado} onChange={(e) => setEstado(e.target.value)}>
                                <option value="">Seleccione Estado</option>
                                <option value="En progreso">En progreso</option>
                                <option value="Inscripciones abiertas">Inscripciones abiertas</option>
                                <option value="Completo">Completo</option>
								<option value="Inscripciones abiertas">Inscripciones abiertas</option>
								<option value="Otro">Otro</option>
                            </select>
                        </div>

						<div className="input-group mb-3">
                          <span > <i className="fas fa-laptop-code"></i> Grupo seccion materia</span>
                            <select className="form-select" value={gruposeccionmateria} onChange={(e) => setgruposeccionmateria(e.target.value)}>
                                <option value="">Seleccione </option>
                                <option value="Grupo A">Grupo A</option>
                                <option value="Grupo B">Grupo B</option>
                                <option value="Grupo C">Grupo C</option>
								<option value="Grupo D">Grupo D</option>
								<option value="Grupo E">Grupo E</option>
								<option value="Grupo F">Grupo F</option>
								<option value="Grupo G">Grupo G</option>
                            </select>
                        </div>
                    <div className="input-group mb-3">
                    <span className="input-group-text"><i className="fas fa-comment"></i></span>
                    <input
                        type="text"
                        id="notasadicionales"
                        className="form-control"
                        placeholder="Notas adicionales..."
                        value={notasadicionales} 
                        onChange={(e) => setNotasadicionales(e.target.value)}
                      />
                    </div>
                    
                    <div className="input-group mb-3">
                    <span className="input-group-text"><i className="fas fa-chalkboard"></i></span>
                    <input
                        type="text"
                        id="codigo"
                        className="form-control"
                        placeholder="Metodos de enseñanza..."
                        value={metodosensenanza}  
                        onChange={(e) => setmetodosensenanza(e.target.value)}
                      />
                    </div>
                    
          
                    
          
                    
					
                    
                        
                    <div className='d-grid col-6 mx-auto'>
                    <div className="d-flex justify-content-center align-items-center h-100">
                      <button onClick={() => validar()} className='btn btn-success'>Guardar</button>
                    </div>
                    </div>
                  
                  <div className='modal-footer'>
                  <div className="d-flex justify-content-center align-items-center h-100">
				  <button onClick={()=> cerrarModal()} type='button' id="btnCerrar" className='btn btn-secondary' data-bs-dismiss='modal'>Cerrar</button>
                  </div>
                  </div>
                </div>
				
              </div>
			  
	</div>
	</div>
    </React.Fragment>
    )}