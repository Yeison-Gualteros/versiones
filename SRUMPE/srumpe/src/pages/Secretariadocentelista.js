import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { show_alert } from '../functions';
import Swal from 'sweetalert2';
import withReactContent from 'sweetalert2-react-content';

export default function Secretariadocentelista(){ 

    const url = 'https://localhost:7284/api/Docente'
    const [Docente, setDocente] = useState([]);
    const [docenteId, setDocenteId] = useState('');
    const [nombre, setNombre] = useState('');
    const [apellido, setApellido] = useState('');
    const [fechaNacimiento, setFechaNacimiento] = useState('');
    const [genero, setGenero]= useState('');
    const [direccion, setDireccion] = useState('');
    const [correo, setCorreo] = useState('');
    const [numeroTelefono, setNumeroTelefono] = useState('');
    const [cursosAsignados, setcursosAsignados]=useState('');
    const [horarioclase, setHorarioclase] = useState('');
    const [estadolaboral, setestadolaboral] = useState(''); 
    const [numeroIdentificacion, setNumeroIdentificacion]=useState('');
    const [ComentariosNotas, setComentariosNotas] = useState('');
   const [fechaContratacion, setfechacontratacion] = useState('');
   const [adjuntardocumentos, setadjuntardocumentos] = useState('');
    const [nivelExperiencia, setNivelExperiencia] = useState('');
    const [tipoPersona, setTipoPersona] = useState('');
    const [tipoDocumento, setTipoDocumento] = useState('');
    const [Aula, setAula] = useState('');
    const [showModal, setShowModal] = useState(false); // Estado para controlar la visibilidad del modal

    const [operation, setOperation] = useState(1);
    const [title, setTitle] = useState('');
    
    
    
    
    
    
    
    const url1 = `https://localhost:7284/api/candidatoEstudiante/${docenteId}`
    const url2 = 'https://localhost:7284/api/cursos';
  const [curso, setCursos] = useState([]);
  const [cursoId, setCursoId] = useState('');
  

  const url3 = 'https://localhost:7284/api/materia'
  const [materia, setMateria] = useState([]);
  const [materiaId, setMateriaId] = useState('');
  


  useEffect(() => {
    fetch(url2)
      .then((response) => response.json())
      .then((data) => setCursos(data))
      .catch((error) => console.error('Error fetching cursos:', error));
  }, []);

  useEffect(() => {
    fetch(url3)
      .then((response) => response.json())
      .then((data) => setMateria(data))
      .catch((error) => console.error('Error fetching materias:', error));
  }, []);
  

    useEffect(() => {
        getDocente();
    }, []);
    
    const getDocente = async () => {
        const respuesta = await axios.get(url);
        setDocente(respuesta.data);
        getCursos(respuesta.data);
        getMateria(respuesta.data);
    }

    const getCursos = async () => {
        const response = await axios.get('https://localhost:7284/api/cursos');
        setCursos(response.data);
    }

    const getMateria = async () => {
        const response = await axios.get('https://localhost:7284/api/materia');
        setMateria(response.data);
    }

    const openModal = (op, Docente) => {
        setOperation(op);
        if (op === 1) {
            setTitle('Registrar Docente');
            setDocenteId('');
            setNombre('');
            setApellido('');
            setNumeroTelefono('');
            setcursosAsignados('');
            setNumeroIdentificacion('');
            setGenero('');
            setFechaNacimiento('');
            setDireccion('');
            setCorreo('');
            setfechacontratacion('');
            setestadolaboral('');
            setNivelExperiencia('');
            setHorarioclase('');
            setComentariosNotas('');
            setTipoPersona('');
            setAula('');
            setCursoId('');
            setMateriaId('');
            setadjuntardocumentos('');
            setTipoDocumento('');
            
            
        }
        if (op === 2) {
            setTitle('Editar Docente');
            setDocenteId(Docente.docenteId);
            setNombre(Docente.nombre);
            setApellido(Docente.apellido);
            setNumeroTelefono(Docente.numeroTelefono);
            setcursosAsignados(Docente.cursosAsignados);
            setNumeroIdentificacion(Docente.numeroIdentificacion);
            setGenero(Docente.genero);
            setFechaNacimiento(Docente.fechaNacimiento);
            setDireccion(Docente.direccion);
            setCorreo(Docente.correo);
            setfechacontratacion(Docente.fechaContratacion);
            setestadolaboral(Docente.estadolaboral);
            setNivelExperiencia(Docente.nivelExperiencia);
            setHorarioclase(Docente.horarioclase);
            setComentariosNotas(Docente.comentariosNotas);
            setTipoPersona(Docente.tipoPersona);
            setAula(Docente.aula);
            setCursoId(Docente.cursoId);
            setMateriaId(Docente.materiaId);
            setadjuntardocumentos(Docente.adjuntardocumentos);
            setTipoDocumento(Docente.tipoDocumento);
        }
        window.setTimeout(function () {
            document.getElementById('Nombre').focus();
        }, 500);
        setShowModal(true);
        
    };
    const cerrarModal = () => {
        const modal = document.getElementById('ModalDocente');
        modal.classList.remove('show'); // Eliminar la clase 'show' para ocultar el modal
        modal.setAttribute('aria-hidden', 'true'); // Asegurarse de que el modal esté marcado como oculto para accesibilidad
        document.body.classList.remove('modal-open'); // Eliminar la clase 'modal-open' del body para permitir el scroll nuevamente
        const modalBackdrop = document.querySelector('.modal-backdrop'); // Eliminar el backdrop del modal si existe
        if (modalBackdrop) {
            document.body.removeChild(modalBackdrop);
        }
        setShowModal(false);
    };
    const validar = () => {
        if (
            !nombre || nombre.trim() === '' ||
        !apellido || apellido.trim() === '' ||
        !numeroTelefono || numeroTelefono.trim() === '' ||
        !numeroIdentificacion || numeroIdentificacion.trim() === '' ||
        !genero || genero.trim() === '' ||
        !cursoId || cursoId.trim() === '' ||
        !direccion || direccion.trim() === '' ||
        !estadolaboral || estadolaboral.trim() === '' ||
        !adjuntardocumentos || adjuntardocumentos.trim() === '' ||
        !tipoDocumento || tipoDocumento.trim() === '' ||
        !tipoPersona || tipoPersona.trim() === '' ||
        !ComentariosNotas || ComentariosNotas.trim() === '' ||
        !nivelExperiencia || nivelExperiencia.trim() === '' ||
        !correo || correo.trim() === ''
        ) {
            show_alert('Por favor completa todos los campos.', 'Campos incompletos');
        } else {
            let parametros;
            let metodo;
    
            if (operation === 1) {
                parametros = { 
                    nombre: nombre, 
                    numeroTelefono: numeroTelefono, 
                    cursosAsignados: cursosAsignados, 
                    numeroIdentificacion: numeroIdentificacion,
                    genero: genero,
                    cursoIds: [cursoId], // Asegurémonos de enviar un array de cursoIds
                    direccion: direccion,
                    estadoLaboral: estadolaboral,
                    horarioClases: horarioclase,
                    comentariosNotas: ComentariosNotas,
                    nivelExperiencia: nivelExperiencia,
                    correoElectronico: correo,
                    materiaIds: [materiaId],
                    apellido: apellido,
                    tipoDocumento: tipoDocumento,
                    tipoPersona: tipoPersona,
                    fechaContratacion: fechaContratacion,
                    adjuntardocumentos: adjuntardocumentos,
                    
                };
                metodo = "POST";
            } else {
                parametros = { 
                    nombre: nombre, 
                    numeroTelefono: numeroTelefono, 
                    cursosAsignados: cursosAsignados, 
                    numeroIdentificacion: numeroIdentificacion,
                    genero: genero,
                    cursoIds: [cursoId], // Asegurémonos de enviar un array de cursoIds
                    direccion: direccion,
                    estadoLaboral: estadolaboral,
                    horarioClases: horarioclase,
                    comentariosNotas: ComentariosNotas,
                    nivelExperiencia: nivelExperiencia,
                    correoElectronico: correo,
                    materiaIds: [materiaId],
                    apellido: apellido,
                    tipoDocumento: tipoDocumento,
                    tipoPersona: tipoPersona,
                    fechaContratacion: fechaContratacion,
                    adjuntardocumentos: adjuntardocumentos,
                };
                metodo = "PUT";
            }
            enviarSolicitud(metodo, parametros);
        }
        cerrarModal();
    };
    

    const enviarSolicitud = async (metodo, parametros) => {
        if (metodo === "POST") {
            const respuesta = await axios.post(url, parametros);
            setDocente(respuesta.data);
            show_alert('Docente Registrado', 'El Docente ha sido registrado correctamente');
        }
        if (metodo === "PUT") {
            if (!docenteId) {
                console.error("DocenteId no está definida");
                return;
            }
            const respuesta = await axios.put(url1, parametros);
            setDocente(respuesta.data);
            show_alert('Docente Editado', 'El Docente ha sido editado correctamente');
        }
    }
    

    const deleteDocente = (docenteId, nombre) => {
        const MySwal = withReactContent(Swal);
        MySwal.fire({
            title:  `¿Seguro quieres eliminar el estudiante ${nombre}?`,
            icon: 'question',
            text: 'Esta acción no se puede deshacer',
            showCancelButton: true,
            confirmButtonText: 'Sí, eliminar',
            cancelButtonText: 'Cancelar',
        }).then(async (result) => {
            if (result.isConfirmed) {
                try {
                    await axios.delete(url1);
                    show_alert('Estudiante eliminado exitosamente', 'info');
                    getDocente();
                } catch (error){
                    show_alert('Error al eliminar al estudiante', 'error');
                    console.error(error);
                }}else {
                    show_alert('El estudiante no fue eliminado', 'info');
                };
            });
    };

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
                    <i className="fas fa-clipboard-list fa-fw"></i> &nbsp; LISTA DE PROFESORES
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
                        data-target="#ModalDocente" // Corregido el target
                    >
                        <a><i className="fas fa-plus fa-fw"></i> Añadir Profesor nuevo</a>
                    </div>
                    </li>
                    <li>
                        <a className="active" href="/Secretariadocentelista"><i className="fas fa-clipboard-list fa-fw"></i> &nbsp; LISTA DE PROFESORES</a>
                    </li>
                    <li>
                        <a style={{color: 'black'}} href="/Secretariadocentebuscar"><i className="fas fa-search fa-fw"></i> &nbsp; BUSCAR PROFESOR/A</a>
                    </li>
                </ul>
            </div>
            <div className="container-fluid">
                            <div className="row mt-3">
                                <div className="col-md-4 offset-4">
                                    <div className="d-gris mx-auto">
                                        <div className="d-flex justify-content-center align-items-center h-100">
                                        

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
								
								<th>NOMBRE</th>
								<th>NUMERO TELEFONO</th>
                                <th>CURSOS ASIGNADOS</th>
								<th>NUMERO IDENTIFICACION</th>
                                <th>GENERO</th>
								<th>ELIMINAR / ACTUALIZAR</th>
							</tr>
						</thead>
						<tbody className="table-group-divider">
							{Docente.map((Docente, i) =>( 
							<tr className="text-center"  key={Docente.DocenteId}>
								<td>{i+1}</td>
								
								<td>{Docente.nombre}</td>
								<td>{Docente.numeroTelefono}</td>
								<td>{Docente.cursosAsignados}</td>
								<td>{Docente.numeroIdentificacion}</td>
                                <td>{Docente.genero}</td>
								<td>
								<button onClick={() => openModal(2, Docente)} className="btn btn-success" data-toggle='modal' data-target='#ModalDocente'>
                          <i className="fas fa-edit"></i>
                        </button>
									 / &nbsp;
									<button onClick={() => deleteDocente(Docente.DocenteId, Docente.nombre, Docente.numeroTelefono, Docente.cursosAsignados, Docente.numeroIdentificacion)} className="btn btn-danger">
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
							<a className="page-link" href="#" tabIndex="-1">Atras</a>
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
    <div id="ModalDocente" cursos={curso} className="modal fade " aria-hidden="true">
        <div className="modal-dialog">
          <div className="modal-content">
            <div className="modal-header">
              <label className="h5">{title}</label>
              <button type="button" className="fas fa-times-circle" aria-label="Close" onClick={cerrarModal}></button>
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
                        <div class="form-group">
                            <span className="input-group-text"><i className="far fa-calendar-alt center"></i>fecha de nacimiento: </span>
                        <input type="date" id="fecha" name="fecha" class="form-control" value={fechaNacimiento} onChange={(e)=>setFechaNacimiento(e.target.value)}/>
                        </div>
                    </div>

                    <div className="input-group mb-3">
                      <span className="input-group-text"><i className="fas fa-phone-alt"></i></span>
                      <input
                        type="number"
                        id="numeroTelefono"
                        className="form-control"
                        placeholder="Numero de Telefono"
                        value={numeroTelefono}
                        onChange={(e) => setNumeroTelefono(e.target.value)}
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
                    <div className="input-group mb-3">
                        <span ><i class="fas fa-id-card"></i> Tipo Documento</span>
                            <select className="form-select" value={tipoDocumento} onChange={(e) => setTipoDocumento(e.target.value)}>
                                <option value="">Seleccione Tipo Documento</option>
                                <option value="cedula">C.C</option>
                                <option value="Targeta de Identidad">T.I</option>
                                <option value="otro">Otro</option>
                            </select>
                        </div>
                        <div className="input-group mb-3">
                      <span className="input-group-text"><i className="fas fa-phone-alt"></i></span>
                      <input
                        type="number"
                        id="numeroIdentificacion"
                        className="form-control"
                        placeholder="Numero de identificacion"
                        value={numeroIdentificacion}
                        onChange={(e) => setNumeroIdentificacion(e.target.value)}
                      />
                    </div>
                    <div className="input-group mb-3">
                            <select className="form-select" value={tipoPersona} onChange={(e) => setTipoPersona(e.target.value)}>
                                <option value="">Seleccione Docente:</option>
                                <option value="Docente Nuevo">Docente Nuevo</option>
                                <option value="Docente Antiguo">Docente Antiguo</option>
                            </select>
                        </div>

                        <div className="input-group mb-3">
                        <div class="form-group">
                            <span className="input-group-text"><i className="far fa-calendar-alt center"></i>fecha de contratacion: </span>
                        <input type="date" id="fecha" name="fecha" class="form-control" value={fechaContratacion} onChange={(e)=>setfechacontratacion(e.target.value)}/>
                        </div>
                    </div>

                     <fieldset>
                  

                 <div className="input-group mb-3"> 
                    <div className="form-group">
                    <span className="input-group-text"><i class="fas fa-school"></i> <span> </span> Cursos</span>
                      
                        
                      
                    <select
  className="form-control"
  name="item_estado"
  id="item_estado"
  value={cursoId} // Aquí debes utilizar selectedCursoID en lugar de descripcion
  onChange={(e) => setCursoId(e.target.value)}
>
  <option value="" disabled>
    Seleccione un Curso
  </option>
  {curso.map((curso) => (
    <option key={curso.cursoId} value={curso.cursoId}>
      {curso.descripcion}
    </option>
  ))}
</select>
|
                    </div>
                  </div>
                </fieldset>
                

                    <div class="input-group mb-3">
                    <span className="input-group-text"><i class="fas fa-envelope"></i></span>
                    <input type="email"
                     className="form-control"
                      id="correo" 
                      placeholder="Dirección de correo electrónico"
                      value={correo}
                      onChange={ (e) => setCorreo (e.target.value)}/>
                   
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
                          <span > <i class="fas fa-chalkboard-teacher"></i> Nivel de Experiencia</span>
                          <select 
                                className="form-select" 
                                value={nivelExperiencia} 
                                onChange={(e) => setNivelExperiencia(e.target.value)}
                            >
                                <option value="">Seleccione nivel</option>
                                <option value="Grado 1">Grado 1</option>
                                <option value="Grado 2">Grado 2</option>
                                <option value="Grado 3">Grado 3</option>
                            </select>
                        </div>

                        

                        <div className="input-group mb-3">
                          <span > <i class="fas fa-chalkboard-teacher"></i> Estado Laboral</span>
                            <select className="form-select" value={estadolaboral} onChange={(e) => setestadolaboral(e.target.value)}>
                                <option value="">Seleccione Estado</option>
                                <option value="Active">Activo</option>
                                <option value="Inactivo">Inactivo</option>
                            </select>
                        </div>

                        

                    <fieldset>
                  <div class="mb-3">
                        
                        <input
                        type="text"
                        id="cargadaDocumento"
                        className="form-control"
                        placeholder="Comentarios"
                        value={ComentariosNotas}
                        onChange={(e) => setComentariosNotas(e.target.value)}
                      />
                      </div>
                      <div class="mb-3">
                        
                        <input
                        type="text"
                        id="cargadaDocumento"
                        className="form-control"
                        placeholder="Inserto documento (SI O NO)"
                        value={adjuntardocumentos}
                        onChange={(e) => setadjuntardocumentos(e.target.value)}
                      />
</div>
                 <div className="input-group mb-3"> 
                    <div className="form-group">
                    <span className="input-group-text"><i class="fas fa-school"></i> <span> </span> horarios</span>
                    <select
                        className="form-control"
                        name="item_estado"
                        id="item_estado"
                        value={materiaId} // Aquí debes utilizar selectedCursoID en lugar de descripcion
                        onChange={(e) => setMateriaId(e.target.value)}
                        >
                        <option value="" disabled>
                            Seleccione un Curso
                        </option>
                        {materia.map((materia) => (
                            <option key={materia.materiaId} value={materia.materiaId}>
                            {materia.nombre}
                            </option>
                        ))}
                        </select>
                    </div>
                  </div>
                </fieldset>
                       

                    
                    
                       
                    <div className='modal-footer'>
                    <div className='d-grid '>
                    <div className="d-flex justify-content-center  ">
                    <button onClick={validar} className="btn btn-outline-success">Guardar</button>

                    </div>
                    </div>


                  
                  
                  <div className="d-flex justify-content-center ">
                  <button onClick={()=> cerrarModal()} type='button' id="btnCerrar" className='btn btn-secondary' data-bs-dismiss='modal'>Cerrar</button>
                  </div>
                  </div>
                </div>
              </div>
            

		</div>
    
    
    	
	</div>
            


        </React.Fragment>
            
    )
}