using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Crud_FluentNHibernate.Models;
using NHibernate;
using NHibernate.Linq;

namespace Crud_FluentNHibernate.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (ISession session = NHibernateHelper.OpeSession())
            {
                var alunos = session.Query<Aluno>().ToList();
                return View(alunos);    
            }
            
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            using (ISession session = NHibernateHelper.OpeSession())
            {
                var aluno = session.Get<Aluno>(id);

                return View(aluno);
            }
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(Aluno aluno)
        {
            try
            {
                // TODO: Add insert logic here
                using (ISession session = NHibernateHelper.OpeSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(aluno);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            using (ISession session = NHibernateHelper.OpeSession())
            {
                var aluno = session.Get<Aluno>(id);
                return View();
            }
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Aluno aluno)
        {
            try
            {
                // TODO: Add update logic here
                using (ISession session = NHibernateHelper.OpeSession())
                {
                    var alunoAlterado = session.Get<Aluno>(id);

                    alunoAlterado.Sexo = aluno.Sexo;
                    alunoAlterado.Curso = aluno.Curso;
                    alunoAlterado.Email = aluno.Email;
                    alunoAlterado.Nome = aluno.Nome;

                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Save(alunoAlterado);
                        transaction.Commit();
                    }
                }

                return RedirectToAction("Index");   
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            using (ISession session = NHibernateHelper.OpeSession())
            {
                var aluno = session.Get<Aluno>(id);
                return View(aluno);
            }
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Aluno aluno)
        {
            try
            {
                using (ISession session = NHibernateHelper.OpeSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        session.Delete(aluno);
                        transaction.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
