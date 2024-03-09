import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { show_alert } from '../functions';
import { Link } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';
import { useEstudiantes } from './EstudianteContext';
import withReactContent from 'sweetalert2-react-content';
import Swal from 'sweetalert2';

export default function Docenteestudiantelista() {
  
  const url = 'https://localhost:7284/api/CandidatoEstudiante'
  const [candidatoEstudiante, setCandidatoEstudiante]= useState([]);
  const [candidatoEstudianteId, setCandidatoEstudianteId] = useState('');
  const [nombre, setNombre] = useState('');
  const [apellido, setApellido] = useState('');

  const url1 = 'https://localhost:7284/api/notas'
  const [notas, setNotas] = useState([]);
  const [notasId, setNotasId] = useState('');
  const [titulo, setTitulo] = useState('');
  const [valor, setValor] = useState('');
  const [fechaCreacion, setFechaCreacion] = useState('');
  
  const [periodo, setPeriodo] = useState('');
  const [operation, setOperation] = useState(1);
  const [title, setTitle] = useState('');

  const url3 = 'https://localhost:7284/api/materia'
  const [materia, setMateria] = useState([]);
  const [materiaId, setMateriaId] = useState('');

  

  useEffect(() => {
    fetch(url3)
      .then((response) => response.json())
      .then((data) => setMateria(data))
      .catch((error) => console.error('Error fetching materias:', error));
  }, []);

  useEffect(() => {
      getCandidatoEstudiante();
      
    },[])

  const getCandidatoEstudiante = async () =>{
    
      const respuesta = await axios.get(url);
      setCandidatoEstudiante(respuesta.data);
      getMateria(respuesta.data);
    
    
  }

  const getNotas = async () =>{
    try{
      const responses = await axios.get(url1);
      setNotas(responses.data);
    }catch (error){
      console.error('Error getting', error);
    }
  }

  const getMateria = async () => {
    const response = await axios.get('https://localhost:7284/api/materia');
    setMateria(response.data);
}

const openModal = (op, candidatoEstudiante) => {
  setOperation(op);
  if (op === 1) {
    setTitle('Registrar Estudiante');
    // Restablecer los valores de los campos al abrir el modal para registrar
    setNotasId('');
    setNombre('');
    setApellido('');
    setTitulo('');
    setValor('');
    setFechaCreacion('');
    setMateria('');
    setPeriodo('');
    setMateriaId('');
  }else if (op === 2) {
    setTitle('Editar Estudiante');
    // Establecer los valores de los campos al abrir el modal para editar
    setNotasId(candidatoEstudiante.notasId);
    setNombre(candidatoEstudiante.nombre);
    setApellido(candidatoEstudiante.apellido);
    setTitulo(candidatoEstudiante.titulo);
    setValor(candidatoEstudiante.valor);
    setFechaCreacion(candidatoEstudiante.fechaCreacion);
    setMateria(candidatoEstudiante.materia);
    setPeriodo(candidatoEstudiante.periodo);
    setMateriaId(candidatoEstudiante.materiaId);
  }
  const nombreInput = document.getElementById('Nombre');
  if (nombreInput) {
    window.setTimeout(function(){
      nombreInput.focus();
    }, 500);
}}

const validar = () => {
  if (valor.trim() === '') {
    show_alert('Escribe el nombre del estudiante', 'Escribe el nombre del nombre');
  }
  else if (titulo.trim() === '') {
    show_alert('Escribe el apellido del estudiante', 'Escribe el estado del apellido');
  }else{
    let parametros;
    let metodo;

    if (operation === 1) {
      parametros = { 
        nombre: nombre, 
        apellido: apellido, 
        titulo: titulo, 
        valor: valor, 
        fechaCreacion: fechaCreacion, 
        materia: materia, 
        periodo: periodo,
        materiaIds: [materiaId],
      };
      metodo = "POST";
      
    }else{
      parametros = { 
        nombre: nombre, 
        apellido: apellido, 
        titulo: titulo, 
        valor: valor, 
        fechaCreacion: fechaCreacion, 
        materia: materia, 
        periodo: periodo,
        notasId: notasId,
        materiaIds: [materiaId],
      };
      metodo = "PUT";
    }
    enviarSolicitud(metodo, parametros);
  }
}



const enviarSolicitud = async (metodo, parametros) => {
  try {
    let respuesta;
    if (metodo === 'POST') {
      respuesta = await axios.post(url1, parametros);
    }else if (metodo === 'PUT') {
      respuesta = await axios.put(`${url1}/${notasId}`, parametros);
    }
    console.log(`Solicitud ${metodo.toUpperCase()} exitosa:`, respuesta.data);
      const mensajeExito = operation === 1 ? 'Estudiante añadido exitosamente' : 'Estudiante editado con éxito';
      show_alert(mensajeExito, 'success');
      document.getElementById('btnCerrar').click();
      getNotas();
  }catch(error){
    show_alert('Error de solicitud', 'error');
    console.error(error);
  }
}

const deletenota = (notasId, titulo) => {
  const MySwal = withReactContent(Swal);
  MySwal.fire({
    title: `¿Está seguro que desea eliminar la nota ${titulo}?`,
    icon: 'warning',
    showCancelButton: true,
    confirmButtonColor: '#3085d6',
    cancelButtonColor: '#d33',
    confirmButtonText: 'Si, eliminar!',
    cancelButtonText: "Cancelar",
  }).then (async (result)=>{
    if (result.isConfirmed) {
      try {
        await axios.delete(`${url1}/${notasId}`);
        const mensajeExito = `Nota ${titulo} eliminada con éxito`;
        show_alert(mensajeExito,'success');
        getNotas();
      } catch (error) {
        show_alert('Error de solicitud', 'error');
        console.error(error);
      }
    }else {
      MySwal.fire({
        title: 'Operación cancelada',
        icon: 'info',
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'OK',
      })
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
                <li>
                  <Link to={'/DocenteReclamos'}>
                    <i className="fas fa-exclamation-circle fa-fw"></i> &nbsp; Reclamos
                  </Link>
                </li>
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
            <div className="table-responsive" style={{ overflowY: 'auto', maxHeight: '70vh' }}>
              <table className="table table-dark table-sm">
                <thead>
                  <tr className="text-center roboto-medium">
                    <th>#</th>
                    <th>ID</th>
                    <th>NOMBRE</th>
                    <th>APELLIDO</th>
                    <th>ASISTENCIA</th>
                    <th>NOTA</th>
                    <th> </th>
                  </tr>
                </thead>
                <tbody>
        {candidatoEstudiante.length > 0 &&
          candidatoEstudiante.map((estudiante, index) => (
            <tr key={estudiante.candidatoEstudianteId} className="text-center">
              <td className="#">{index + 1}</td>
              <td className="ID">{estudiante.candidatoEstudianteId}</td>
              <td className="nombre">{estudiante.nombre}</td>
              <td className="apellido">{estudiante.apellido}</td>
              <td className="asistencia">
                {/* Aquí puedes mostrar la asistencia si es necesario */}
              </td>
              <td className="nota">
                {/* Botón para abrir el modal y editar las notas */}
                <button onClick={() => openModal(1,estudiante.candidatoEstudianteId, estudiante.notasId)} className="btn btn-success" data-toggle='modal' data-target='#ModalDocente'>
                  Editar Notas
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
                  <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div className="modal-body">
                  <input type="hidden" id="candidatoEstudianteId" />
                  <div className="input-group mb-3">
                    <span className="input-group-text">
                      <i className="fas fa-text-width"></i>
                    </span>
                    <input
                      type="text"
                      id="Nombre"
                      className="form-control"
                      placeholder="Titulo..."
                      value={titulo}
                      onChange={(e) => setTitulo(e.target.value)}
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
                      value={valor}
                      onChange={(e) => setValor(e.target.value)}
                    />
                  </div>
                  <div className="input-group mb-3">
                        <div class="form-group">
                            <span className="input-group-text"><i className="far fa-calendar-alt center">  </i> Fecha de creaccion de nota: </span>
                        <input type="date" id="fecha" name="fecha" class="form-control" value={fechaCreacion} onChange={(e)=>setFechaCreacion(e.target.value)}/>
                        </div>
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
