using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ProjectBlazorApp_Server.Data;

var builder = WebApplication.CreateBuilder(args);       // args can be used in build (Line 12)

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else        // to show developer exception page
{
    app.UseDeveloperExceptionPage();        // if environment variable is development
                                            // (in Properties -> launchSettings.json)
                                            // and project is run on Local, 
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();       // Routing => wrt HTTP pages; here i.e., to match HTTP requests, n dispatch them to the app's
                        // exectable endpoints

app.MapBlazorHub();                 // adding endpoint for Blazor
                                    // + configuring 'SignalR' connection for Blazer app (just this one line)
                                    
                                    // SignalR - established over network to handle UI updates (to rerender page
                                    //          or a part of it) n event forwarding (like button clicks, to trigger
                                    //          any routing to different pages or update things in UI)
                                    //          between Blazor app running on Browser n ASP.NET core app running
                                    //          on the Server
                                    
                                    // In all helps keep the app responsive like the JS frameworks

app.MapFallbackToPage("/_Host");    // Configures the default routing path, so when its not known where to / how
									// to route to, the request can be routed to this default page
                                    // look into _Host.cshtml (under Pages)

app.Run();
