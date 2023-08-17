using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MSCMD.Model;

namespace MSCMD
{
	public class MscmdContext : DbContext
	{
		public DbSet<Project> Projects { get; set; }
		public DbSet<Agent> Agents { get; set; }
		public DbSet<HumanResource> HumanResources { get; set; }
		public DbSet<Activity> Activities { get; set; }
		public DbSet<Element> Elements { get; set; }
		public DbSet<Organization> Organizations { get; set; }
		public DbSet<AgentResourceRelationship> AgentResourceRelationships { get; set; }
		public DbSet<ActivityActivityRelationship> ActivityActivityRelationships { get; set; }
		public DbSet<ActivityElementRelationship> ActivityElementRelationships { get; set; }
		public DbSet<ElementElementRelationship> ElementElementRelationships { get; set; }
		public DbSet<AgentActivityRelationship> AgentActivityRelationships { get; set; }
		public DbSet<Subprocess> Subprocesses { get; set; }
		public DbSet<SubprocessActivity> SubprocessActivities { get; set; }
		public DbSet<Subsystem> Subsystems { get; set; }
		public DbSet<ElementSubsystem> ElementSubsystems { get; set; }
		public DbSet<OrganizationAgent> OrganizationAgents { get; set; }
		public DbSet<AgentSubordination> AgentSubordinations { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseSqlite("Data Source=mscmd.db");

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Project>().HasKey(e => e.projectId).HasName("PRIMARY");

			modelBuilder.Entity<Agent>().HasKey(e => e.AgentId).HasName("PRIMARY");

			modelBuilder.Entity<HumanResource>().HasKey(e => e.PersonId).HasName("PRIMARY");

			modelBuilder.Entity<Activity>().HasKey(e => e.ActivityId).HasName("PRIMARY");

			modelBuilder.Entity<Element>().HasKey(e => e.ElementId).HasName("PRIMARY");

			modelBuilder.Entity<Organization>().HasKey(e => e.SectorId).HasName("PRIMARY");

			modelBuilder.Entity<AgentResourceRelationship>().HasKey(e => e.RelationshipId).HasName("PRIMARY");

			modelBuilder.Entity<ActivityActivityRelationship>().HasKey(e => e.RelationshipId).HasName("PRIMARY");

			modelBuilder.Entity<ActivityElementRelationship>().HasKey(e => e.RelationshipId).HasName("PRIMARY");

			modelBuilder.Entity<ElementElementRelationship>().HasKey(e => e.RelationshipId).HasName("PRIMARY");

			modelBuilder.Entity<AgentActivityRelationship>().HasKey(e => e.RelationshipId).HasName("PRIMARY");

			modelBuilder.Entity<AgentSubordination>().HasKey(e => e.AgentSubordinationId).HasName("PRIMARY");

			modelBuilder.Entity<Subprocess>()
			   .HasMany(e => e.Activities)
			   .WithMany(e => e.Subprocesses)
			   .UsingEntity<SubprocessActivity>();

			modelBuilder.Entity<Subsystem>()
			   .HasMany(e => e.Elements)
			   .WithMany(e => e.Subsystems)
			   .UsingEntity<ElementSubsystem>();

			modelBuilder.Entity<Organization>()
			   .HasMany(e => e.Agents)
			   .WithMany(e => e.Organizations)
			   .UsingEntity<OrganizationAgent>();

			modelBuilder.Entity<AgentSubordination>()
				.HasOne(e => e.FunctionalSubordination)
				.WithMany(e => e.FunctionalSubordinationsOf)
				.HasForeignKey(e => e.FunctionalSubordinationId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<AgentSubordination>()
				.HasOne(pt => pt.Agent)
				.WithMany(t => t.FunctionalSubordinations)
				.HasForeignKey(pt => pt.AgentId);

	


		}
	}
}
