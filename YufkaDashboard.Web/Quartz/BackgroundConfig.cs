using Quartz.Impl;
using Quartz;

namespace YufkaDashboard.Web.Quartz
{
    public class BackgroundConfig
    {
        public static async Task Start()
        {
            // Scheduler oluştur
            IScheduler scheduler = await new StdSchedulerFactory().GetScheduler();
            await scheduler.Start();

            // Job ve Trigger Tanımla
            IJobDetail job = JobBuilder.Create<BackgroundJob>()
                                       .WithIdentity("jobEndDay")
                                       .Build();

            ITrigger trigger = TriggerBuilder.Create()
                                             .WithIdentity("triggerEndDay")
                                             .WithCronSchedule("0 0 22 * * ?")
                                             .Build();

            // Job’ı çalıştır
            await scheduler.ScheduleJob(job, trigger);
        }
    }
}
