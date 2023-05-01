import subprocess

# Run "docker ps -a" and capture the output
output = subprocess.check_output(["docker", "ps", "-a"]).decode("utf-8")

# Split the output into lines and remove the header row
lines = output.strip().split("\n")[1:]

for line in lines:
    parts = line.split()

    # Extract the container name and exposed ports
    name = parts[-1]
    ports = parts[-2]

    # Look for the HTTPS port number in the exposed ports
    for port in ports.split(","):
        if "->443/tcp" in port:
            https_port = port.split(":")[-1].split("-")[0]
            https_address = f"https://localhost:{https_port}"
            print(f"HTTPS for container {name}")
            print(f"{https_address}")
            exit()

print("No running containers with HTTPS found")
