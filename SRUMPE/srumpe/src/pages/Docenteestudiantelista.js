import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { show_alert } from '../functions';
import { Link } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';
import { useEstudiantes } from './EstudianteContext';
import withReactContent from 'sweetalert2-react-content';
import Swal from 'sweetalert2';

export default function Docenteestudiantelista() {
  
  const url = 'https://localhost:5001/api/notas'

  const [estudianteSeleccionado, setEstadoSeleccionado] = useState('');
  
  const [notas, setNotas] = useState([]);
  const [notaId, setNotaId] = useState('');
  const [estudiante, setEstudiante] = useState('');
  const [curso, setcurso] = useState('');
  const [periodoAcademico, setPeriodoAcademico] = useState('');
  const [fechaCreacion, setFechaCreacion] = useState('');
  const [materia, setMateria] = useState('');
  const [valorNota, setValorNota] = useState('');
  const [tipoNota, setTipoNota] = useState('');
  const [descripcionNota, setDescripcionNota] = useState('')

  const [showModal, setShowModal] = useState(false);
  const [operation, setOperation] = useState(1);
  const [title, setTitle] = useState('');

  const url1 = 'https://localhost:5001/api/candidatoEstudiante'
  const [candidatoEstudiante, setCandidatoEstudiante] = useState([])
  const [candidatoEstudianteId, setCandidatoEstudianteId] = useState('');
  //const [nombre, setNombre] = useState('');

  useEffect(() => {
    fetch(url1)
      .then((response) => response.json())
      .then((data) => setCandidatoEstudiante(data))
      .catch((error) => console.error('Error fetching estudiante:', error));
  }, []);

  useEffect(() =>{
    getNotas();
  }, []);

  const getNotas = async () => {
    const respuesta = await axios.get(url);
    setNotas(respuesta.data);
    getcandidatoEstudiante(respuesta.data);
  }
  const getcandidatoEstudiante = async () => {
    try {
      const response = await axios.get('https://localhost:5001/api/candidatoEstudiante');
      const candidatos = response.data.candidatosEstudiantes; // Por ejemplo, si la propiedad se llama 'candidatosEstudiantes'
      setCandidatoEstudiante(candidatos);
    } catch (error) {
      console.error('Error fetching candidatoEstudiante:', error);
    }
  }
  
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

const openModal = (op, nota) => {
  setOperation(op);
  if (op === 1) {
    setTitle('Registrar nota');
    setNotaId('');
    setEstudiante('');
    setcurso('');
    setPeriodoAcademico('');
    setFechaCreacion('');
    setMateria('');
    setValorNota('');
    setTipoNota('');
    setDescripcionNota('');
  }
  if (op === 2) {
    setTitle('editar Nota');
    setNotaId(nota.notasId);
    setEstudiante(nota.estudiante);
    setcurso(nota.curso);
    setPeriodoAcademico(nota.periodoAcademico);
    setFechaCreacion(nota.fechaCreacion);
    setMateria(nota.materia);
    setValorNota(nota.valorNota);
    setTipoNota(nota.tipoNota);
    setDescripcionNota(nota.descripcionNota);
    
  }
  window.setTimeout(function() {
    document.getElementById('Nombre').focus();
  },500);
  setShowModal(true);
}

const validar = () => {
  if (estudiante === '') {
    Swal.fire({
      icon: 'error',
      title: 'Error',
      text: 'Debe seleccionar un estudiante',
    })
  }
  if (curso === '') {
    Swal.fire({
      icon: 'error',
      title: 'Error',
      text: 'Debe seleccionar un curso',
    })
  
}
if (periodoAcademico === '') {
  Swal.fire({
    icon: 'error',
    title: 'Error',
    text: 'Debe seleccionar un periodo académico',
  })
  
}
if (fechaCreacion === '') { 
  Swal.fire({
    icon: 'error',
    title: 'Error',
    text: 'Debe seleccionar una fecha de creación',
  })
  
}
if (materia === '') {
  Swal.fire({
    icon: 'error',
    title: 'Error',
    text: 'Debe seleccionar una materia',
  })
  
}
if (valorNota === ''){
  Swal.fire({
    icon: 'error',
    title: 'Error',
    text: 'Debe ingresar un valor de nota',
  })
  
}
if (tipoNota === '') {
  Swal.fire({
    icon: 'error',
    title: 'Error',
    text: 'Debe seleccionar un tipo de nota',
  })
}
if (descripcionNota === '') {
  Swal.fire({
    icon: 'error',
    title: 'Error',
    text: 'Debe ingresar una descripción de nota',
  })
  
}else {
  let parametros;
  let metodo;
  
  if (operation === 1) {
    parametros = {
      notaId: notaId,
      estudiante: estudiante,
      curso: curso,
      periodoAcademico: periodoAcademico,
      fechaCreacion: fechaCreacion,
      materia: materia,
      valorNota: valorNota,
      tipoNota: tipoNota,
      descripcionNota: descripcionNota
    }
    metodo = 'POST';
  }else {
    parametros = {
      notasId: notaId,
      
      estudiante: estudiante,
      curso: curso,
      periodoAcademico: periodoAcademico,
      fechaCreacion: fechaCreacion,
      materia: materia,
      valorNota: valorNota,
      tipoNota: tipoNota,
      descripcionNota: descripcionNota
    }
    metodo = 'PUT';
  }
  enviarSolicitud(metodo, parametros);
  cerrarModal();
}
}

const enviarSolicitud = async (metodo, parametros) => {
  try {
    let respuesta;
    if (metodo === 'POST') {
      respuesta = await axios.post(url, parametros);
    }else if (metodo === 'PUT') {
      respuesta = await axios.put(`${url}/${notaId}`, parametros);
    }
    console.log(`Solicitud ${metodo.toUpperCase()} exitosa:`, respuesta.data);
    const mensajeExito = operation === 1? 'Nota Añadida exitasamente': 'Nota editada exitasamente';
    show_alert(mensajeExito, 'success');
    document.getElementById('btnCerrar').click();
    getNotas();
  }catch (e) {
    show_alert('Error en la solicitud', 'error')
    console.error(e);
  }
}

const deleteDocente = (notaId, tipoNota) => {
  const MySwal = withReactContent(Swal);
  MySwal.fire({
    title: '¿Estás seguro que desea eliminar la nota'+ tipoNota+'?',
    text: "No podras revertir esta acción!",
    icon: 'warning',
    showCancelButton: true,
    confirmButtonColor: '#3085d6',
    cancelButtonColor: '#d33',
    confirmButtonText: 'Si, Borrar!',
    cancelButtonText: "Cancelar",
  }).then(async (result) => {
    if (result.isConfirmed) {
      try {
        const respuesta = await axios.delete(`${url}/${notaId}`);
        console.log(`Solicitud Borrar ${tipoNota.toUpperCase()} exitosa:`, respuesta.data);
        const mensajeExito = tipoNota === 'Nota'? 'Nota Borrada exitasamente': 'Nota Borrada exitasamente';
        show_alert(mensajeExito,'success');
        document.getElementById('btnCerrar').click();
        getNotas();
      }catch (e) {
        show_alert('Error en la solicitud', 'error');
        console.error(e); // Aquí imprime el error en la consola para obtener más información
      }
    }
  })
}

  return (
    <React.Fragment>
      <main className="full-box main-container">
        <section className="full-box nav-lateral">
          <div className="full-box nav-lateral-bg show-nav-lateral"></div>
          <div className="full-box nav-lateral-content">
            <figure className="full-box nav-lateral-avatar">
              <i className="far fa-times-circle show-nav-lateral"></i>
              <img src="/assets/avatar/Avatar_negro.jpg" className="img-fluid" alt="Avatar" />
              <figcaption className="roboto-medium text-center">
                Nombre de docente <br />
                <small className="roboto-condensed-light">
                  <p>
                    <span className="badge badge-success">Docente</span>
                  </p>
                </small>
              </figcaption>
            </figure>
            <div className="full-box nav-lateral-bar"></div>
            <nav className="full-box nav-lateral-menu">
              <ul>
                <li>
                  <Link to={'/Docente'}>
                    <i className="fab fa-dashcube fa-fw"></i> &nbsp; Inicio
                  </Link>
                </li>
                <li>
                  <Link to={'/Docenteestudiantelista'}>
                    
                      <i className="fas fa-clipboard-list fa-fw"></i> &nbsp; Lista De Estudiante
                    
                  </Link>
                </li>
                <li>
                  <a href="#" className="nav-btn-submenu">
                    <i className="fas fa-layer-group fa-fw"></i> &nbsp; Cursos{' '}
                    <i className="fas fa-chevron-down"></i>
                  </a>
                  <ul>
                    <li>
                      <Link to={'/Docenteelegircurso'}>
                        <i className="fas fa-clipboard-list fa-fw"></i> &nbsp; Elegir Cursos
                      </Link>
                    </li>
                  </ul>
                </li>
                <li>
                  <a href="#" className="nav-btn-submenu">
                    <i className="fas fa-users fa-fw"></i> &nbsp; Estudiantes{' '}
                    <i className="fas fa-chevron-down"></i>
                  </a>
                  <ul>
                    <li>
                      <Link to={'/Docenteestudiantelista'}>
                        <i className="fas fa-clipboard-list fa-fw"></i> &nbsp; Lista De Estudiante
                      </Link>
                    </li>
                    <li>
                      <Link to={'/Docentebuscarestudiante'}>
                        <i className="fas fa-search fa-fw"></i> &nbsp; Buscar Estudiante
                      </Link>
                    </li>
                  </ul>
                </li>
                {/*<li>
                  <Link to={'/DocenteReclamos'}>
                    <i className="fas fa-exclamation-circle fa-fw"></i> &nbsp; Reclamos
  </Link>
  </li>*/}
              </ul>
            </nav>
          </div>
        </section>

        <section className="full-box page-content">
          <nav className="full-box navbar-info">
            <a className="float-left show-nav-lateral">
              <i className="fas fa-exchange-alt"></i>
            </a>
            <Link to={'/Docente'}>
              <i className="fab fa-dashcube fa-fw"></i> &nbsp; Inicio
            </Link>
            <a className="btn-exit-system">
              <i className="fas fa-power-off"></i>
            </a>
          </nav>
          

          <div className="full-box page-header">
            <h3 className="text-left">
              <i className="fas fa-clipboard-list fa-fw"></i> &nbsp; LISTA DE ESTUDIANTES
            </h3>
            <p className="text-justify"></p>
          </div>
          <div className="container-fluid">
                <ul className="full-box list-unstyled page-nav-tabs">
                    <li>
                    <div
                        onClick={() => openModal(1)}
                        data-toggle="modal"
                        data-target="#ModalDocente" 
                    >
                        <a><i className="fas fa-plus fa-fw"></i> Añadir Nota nueva</a>
                    </div>
                    </li>
                    <li>
                        <a className="active" href="/Secretariadocentelista"><i className="fas fa-clipboard-list fa-fw"></i> &nbsp; LISTA DE NOTAS</a>
                    </li>
                    
                </ul>
            </div>

          <div className="container-fluid">
            <div className="table-responsive" style={{ overflowY: 'auto', maxHeight: '70vh' }}>
              <table className="table table-dark table-sm">
                <thead>
                  <tr className="text-center roboto-medium">
                    <th>#</th>
                    
                    <th>NOMBRE</th>
                    <th>MATERIA</th>
                    <th>VALOR DE LA NOTA</th>
                    <th>TIPO DE NOTA</th>
                    <th>ASISTENCIA</th>
                    <th>EDITAR NOTA</th>
                    <th>ELIMINAR NOTA</th>
                  </tr>
                </thead>
                <tbody>
        {notas.length > 0 &&
          notas.map((notas, index) => (
            <tr key={notas.notaId} className="text-center">
              <td className="#">{index + 1}</td>
              
              <td className="nombre">{notas.estudiante}</td>
              <td className="apellido">{notas.materia}</td>
              <td className="apellido">{notas.valorNota}</td>
              <td className="apellido">{notas.tipoNota}</td>
              <td className="asistencia">
                {/* Aquí puedes mostrar la asistencia si es necesario */}
              </td>
              <td className="nota">
                {/* Botón para abrir el modal y editar las notas */}
                <button onClick={() => openModal(2,notas)} className="btn btn-success" data-toggle='modal' data-target='#ModalDocente'>
                  Editar Notas
                </button>
              </td>
              <td><button onClick={() => deleteDocente(notas.notaId)} className="btn btn-danger">
  <i className="far fa-trash-alt"></i>
</button>
</td>
            </tr>
          ))}
      </tbody>
              </table>
            </div>
          </div>

          
                <div id="ModalDocente" className="modal fade" aria-hidden="true">
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
              <div className="input-group "> 
                    
                    <span className="input-group-text"><i className="fas fa-clipboard-list fa-fw"></i> <span> </span> </span>
                    <input
                      type="text"
                      id="Nombreestudiante"
                      className="form-control"
                      placeholder="Titulo de la nota..."
                      value={tipoNota}
                      onChange={(e) => setTipoNota(e.target.value)}
                    />
                </div>
                  <div className="input-group mb-3">
                    <span className="input-group-text">
                      <i className="fas fa-sort-numeric-up-alt"></i>
                    </span>
                    <input
                      type="number"
                      id="Valor"
                      className="form-control"
                      placeholder="Valor de la Nota"
                      value={valorNota}
                      onChange={(e) => setValorNota(e.target.value)}
                    />
                  </div>
                  <div className="input-group mb-3">
                        <div class="form-group">
                            <span className="input-group-text"><i className="far fa-calendar-alt center">  </i> Fecha de creaccion de nota: </span>
                        <input type="date" id="fecha" name="fecha" class="form-control" value={fechaCreacion} onChange={(e)=>setFechaCreacion(e.target.value)}/>
                        </div>
                    </div>
                    <div className="input-group mb-3">
                    <span className="input-group-text">
                      <i className="fas fa-audio-description"></i>
                    </span>
                    <input
                      type="text"
                      id="Nombre"
                      className="form-control"
                      placeholder="Agrega una descripcion de la nota..."
                      value={descripcionNota}
                      onChange={(e) => setDescripcionNota(e.target.value)}
                    />
                  </div>
                  <div className="input-group "> 
                    
                    <span className="input-group-text"><i className="fas fa-clipboard-list fa-fw"></i> <span> </span> </span>
                    <input
                      type="text"
                      id="Nombreestudiante"
                      className="form-control"
                      placeholder="Agrega nombre del estudiante..."
                      value={estudiante}
                      onChange={(e) => setEstudiante(e.target.value)}
                    />
                    
  </div>
  <div className="input-group mb-3">
						<span className="input-group-text"><i className="fas fa-school"></i></span>
						<select
							className="form-select"
							value={periodoAcademico} // Utilizando la variable de estado
							onChange={(e) => setPeriodoAcademico(e.target.value)} // Utilizando la función setDepartamentoAcademico para actualizar el estado
						>
							<option value="">Selecciona el periado académico</option>
							<option value="Primer Periodo">Primer Periodo</option>
							<option value="Segundo Periodo">Segundo Periodo</option>
              <option value="Tercero Periodo">Tercero Periodo</option>
              <option value="Cuarto Periodo">Cuarto Periodo</option>
						</select>
					</div>
                    {/*<div className="input-group mb-3"> 
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
                        </div>*/}
                  {/*<div className="input-group mb-3">
                      <span className="input-group-text"><i className="fas fa-chalkboard-teacher"></i></span>
                      <select
            className="form-control"
            name="item_estado"
            id="item_estado"
            value={candidatoEstudiante} placeholder
            onChange={(e) => setCandidatoEstudianteId(e.target.value)}
          >
            <option value="" disabled>
              Seleccione el Estudiante
            </option>
            {candidatoEstudiante.length > 0 ? (
              candidatoEstudiante.map((candidatoEstudiante) => (
                <option key={candidatoEstudiante.candidatoEstudianteId} value={candidatoEstudiante.nombre}>
                  {candidatoEstudiante.nombre}
                </option>
              ))
            ) : (
              <option value="" disabled>
                Cargando estudiante...
              </option>
            )}
          </select>

          
            </div>*/}
          {/*<div className="input-group mb-3"> 
                    <div className="form-group">
                    <span className="input-group-text"><i className="fas fa-clipboard-list fa-fw"></i> <span> </span> Cursos</span>
                    <select
  className="form-control"
  name="item_estado"
  id="item_estado"
  value={cursoId}
  onChange={(e) => setCursoId(e.target.value)}
>
  <option value="" disabled>
    Seleccione un Curso
  </option>
  {cursos.map((cursos) => (
    <option key={cursos.cursoId} value={cursos.cursoId}>
      {cursos.codigocurso}
    </option>
  ))} 

</select>
                    </div>
  </div>*/}
                  <div className="d-grid col-6 mx-auto">
                    <div className="d-flex justify-content-center align-items-center h-100">
                      <button onClick={() => validar()} className="btn btn-success">
                        Guardar
                      </button>
                    </div>
                  </div>
                </div>
                <div className="modal-footer">
                  <div className="d-flex justify-content-center align-items-center h-100">
                    <button
                      type="button"
                      id="btnCerrar"
                      className="btn btn-secondary"
                      data-bs-dismiss="modal"
                    >
                      Cerrar
                    </button>
                  </div>
                </div>
              </div>
            </div>
          </div>
          
        </section>
      </main>
    </React.Fragment>
  );
}
