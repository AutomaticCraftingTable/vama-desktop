FROM mcr.microsoft.com/dotnet/sdk:9.0

ARG USERNAME=docker-shell
ARG USER_ID=1000
ARG GROUP_ID=100

RUN getent passwd ${USER_ID} \
 && sudo usermod -m -d /home/${USERNAME} -g ${GROUP_ID} -aG sudo -l ${USERNAME} $(id -nu ${USER_ID}) \
 && sudo passwd -d ${USERNAME} \
 || adduser --disabled-password --uid ${USER_ID} --gid ${GROUP_ID} ${USERNAME}

USER $USERNAME

RUN echo 'export PS1="\[\e[34m\][\u:\[\e[35m\]\w\[\e[34m\]]$\[\e[0m\] "' \
 >> /home/${USERNAME}/.bashrc
